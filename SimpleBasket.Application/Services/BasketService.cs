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
        private IList<Basket> _basket;

        public BasketService(ISimpleBasketDbContext simpleBasketDbContext, IProductService productService)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
            _productService = productService;
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

            //Check if the product can be added to the basket
            bool checkProductForAddToBasket = await _productService.CheckProductForAddToBasket(addProductToBasketCommand.ProductDetailId, addProductToBasketCommand.Quantity);

            if (!checkProductForAddToBasket)
                return null;

            //Check if the product is already in the basket
            var checkIfProductAlreadyInBasket = await CheckIfProductAlreadyInBasket(addProductToBasketCommand);

            //If it already exists, increase the quantity, if not add to basket
            if (checkIfProductAlreadyInBasket)
                await IncreaseProductQuantityInBasket(addProductToBasketCommand);
            else
                await AddNewProductToBasket(addProductToBasketCommand);

            return await GetBasketProductList(new GetBasketProductListQuery(addProductToBasketCommand.CustomerId));
        }

        private async Task IncreaseProductQuantityInBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            var basketProduct = _basket.Where(x => x.ProductDetailId == addProductToBasketCommand.ProductDetailId).FirstOrDefault();
            basketProduct.Quantity += addProductToBasketCommand.Quantity;
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

        private async Task<bool> CheckIfProductAlreadyInBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            if (_basket == null)
                await InitBasket(addProductToBasketCommand.CustomerId);

            if (_basket != null && _basket.Count == 0)
                return false;

            return _basket.Any(x => x.ProductDetailId == addProductToBasketCommand.ProductDetailId);
        }

        private async Task InitBasket(int customerId) =>
            _basket = await _simpleBasketDbContext.Baskets.Where(x => x.CustomerId == customerId).ToListAsync();
    }
}
