using Microsoft.EntityFrameworkCore;
using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Baskets.Queries.GetBasketProductList;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using SimpleBasket.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly ISimpleBasketDbContext _simpleBasketDbContext;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private IList<Basket> _baskets;
        private Basket _basket;

        public BasketService(ISimpleBasketDbContext simpleBasketDbContext, IProductService productService, ICustomerService customerService)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<BasketDto> GetBasketProductList(GetBasketProductListQuery getBasketProductListQuery)
        {
            if (getBasketProductListQuery == null)
                return null;

            var baskets = await _simpleBasketDbContext.Baskets.Where(x => x.CustomerId == getBasketProductListQuery.CustomerId).ToListAsync();

            if (baskets == null || baskets.Count == 0)
                return null;

            var prods = new List<BasketProduct>();
            foreach (var basket in baskets)
                prods.Add(new BasketProduct
                {
                    Product = await _productService.GetProductWithOptions(basket.ProductDetailId),
                    Quantity = basket.Quantity
                });

            return new BasketDto
            {
                Products = prods,
                BasketPrice = prods.Sum(x => x.Product.Price * x.Quantity)
            };
        }

        public async Task<BasketDto> AddProductToBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            if (addProductToBasketCommand == null)
                return null;

            if (addProductToBasketCommand.Quantity <= 0)
                return null;

            //Check if this customer exists
            bool isCustomerExist = await _customerService.IsCustomerExist(addProductToBasketCommand.CustomerId);
            if (!isCustomerExist)
                return null;

            //Check if the product can be added to the basket
            var quantityOfProductInBasket = await GetQuantityOfProductInBasket(addProductToBasketCommand.CustomerId, addProductToBasketCommand.ProductDetailId);
            bool checkProductForAddToBasket = await _productService.CheckProductForAddToBasket(addProductToBasketCommand, quantityOfProductInBasket);
            if (!checkProductForAddToBasket)
                return null;

            //Check if the product is already in the basket
            var checkIfProductAlreadyInBasket = await CheckIfProductAlreadyInBasket(addProductToBasketCommand.CustomerId, addProductToBasketCommand.ProductDetailId);

            //If it already exists, increase the quantity, if not add to basket
            if (checkIfProductAlreadyInBasket)
                await IncreaseProductQuantityInBasket(addProductToBasketCommand);
            else
                await AddNewProductToBasket(addProductToBasketCommand);

            return await GetBasketProductList(new GetBasketProductListQuery(addProductToBasketCommand.CustomerId));
        }

        private async Task IncreaseProductQuantityInBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            if (_basket == null)
                await InitBasket(addProductToBasketCommand.CustomerId, addProductToBasketCommand.ProductDetailId);

            _basket.Quantity += addProductToBasketCommand.Quantity;
            await _simpleBasketDbContext.SaveChangesAsync();
        }

        private async Task AddNewProductToBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            var basketProduct = new Basket
            {
                CustomerId = addProductToBasketCommand.CustomerId,
                ProductDetailId = addProductToBasketCommand.ProductDetailId,
                Quantity = addProductToBasketCommand.Quantity
            };

            _simpleBasketDbContext.Baskets.Add(basketProduct);
            await _simpleBasketDbContext.SaveChangesAsync();
        }

        private async Task<bool> CheckIfProductAlreadyInBasket(int customerId, int productDetailId)
        {
            if (_basket == null)
                await InitBasket(customerId, productDetailId);

            return _basket != null;
        }

        private async Task InitBasket(int customerId) =>
            _baskets = await _simpleBasketDbContext.Baskets.Where(x => x.CustomerId == customerId).ToListAsync();

        private async Task InitBasket(int customerId, int productDetailId) =>
            _basket = await _simpleBasketDbContext.Baskets.Where(x => x.CustomerId == customerId && x.ProductDetailId == productDetailId).FirstOrDefaultAsync();

        public async Task<int> GetQuantityOfProductInBasket(int customerId, int productDetailId)
        {
            if (_basket == null)
                await InitBasket(customerId, productDetailId);

            return _basket != null ? _basket.Quantity : 0;
        }
    }
}
