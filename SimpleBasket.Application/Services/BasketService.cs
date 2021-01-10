using Microsoft.EntityFrameworkCore;
using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Baskets.Queries.GetBasketProductList;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly ISimpleBasketDbContext _simpleBasketDbContext;
        private readonly IProductService _productService;

        public BasketService(ISimpleBasketDbContext simpleBasketDbContext, IProductService productService)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
            _productService = productService;
        }

        public Task<BasketDto> AddProductToBasket(AddProductToBasketCommand addProductToBasketCommand)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BasketDto> GetBasketProductList(GetBasketProductListQuery getBasketProductListQuery)
        {
            var baskets = await _simpleBasketDbContext.Baskets.Where(x => x.CustomerId == getBasketProductListQuery.CustomerId).ToListAsync();

            if (baskets == null || baskets.Count == 0)
                return null;

            var prods = new List<BasketProduct>();
            foreach (var basket in baskets)
                prods.Add(new BasketProduct
                {
                    Product = await _productService.GetProduct(basket.ProductDetailId),
                    Quantity = basket.Quantity
                });

            return new BasketDto
            {
                Products = prods,
                BasketPrice = prods.Sum(x => x.Product.Price * x.Quantity)
            };
        }
    }
}
