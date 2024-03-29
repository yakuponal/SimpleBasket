﻿using Microsoft.EntityFrameworkCore;
using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ISimpleBasketDbContext _simpleBasketDbContext;
        private ProductDto _product;

        public ProductService(ISimpleBasketDbContext simpleBasketDbContext)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
        }

        public async Task<IList<ProductDto>> GetProducts()
        {
            var products = await _simpleBasketDbContext.ProductDetails
                .Join(_simpleBasketDbContext.Products,
                    productDetail => productDetail.ProductId,
                    product => product.ProductId,
                    (productDetail, product) => new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductDetailId = productDetail.ProductDetailId,
                        ProductName = product.ProductName,
                        ProductDetailName = productDetail.ProductDetailName,
                        Description = productDetail.Description,
                        Price = productDetail.Price,
                        Stock = productDetail.Stock
                    }).ToListAsync();

            foreach (var product in products)
                product.ProductOptions = await GetProductOptions(product.ProductDetailId);

            return products;
        }

        public async Task<ProductDto> GetProduct(int productDetailId) =>
            await _simpleBasketDbContext.ProductDetails.Where(x => x.ProductDetailId == productDetailId)
                .Join(_simpleBasketDbContext.Products,
                    productDetail => productDetail.ProductId,
                    product => product.ProductId,
                    (productDetail, product) => new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductDetailId = productDetail.ProductDetailId,
                        ProductName = product.ProductName,
                        ProductDetailName = productDetail.ProductDetailName,
                        Description = productDetail.Description,
                        Price = productDetail.Price,
                        Stock = productDetail.Stock
                    }).FirstOrDefaultAsync();

        public async Task<IList<ProductOptionDto>> GetProductOptions(int productDetailId) =>
            await (from productOption in _simpleBasketDbContext.ProductOptions.Where(x => x.ProductDetailId == productDetailId)
                   join option in _simpleBasketDbContext.Options on productOption.OptionId equals option.OptionId
                   join optionGroup in _simpleBasketDbContext.OptionGroups on option.OptionGroupId equals optionGroup.OptionGroupId
                   select new ProductOptionDto
                   {
                       OptionGroupId = optionGroup.OptionGroupId,
                       OptionId = option.OptionId,
                       OptionGroupName = optionGroup.OptionGroupName,
                       OptionName = option.OptionName
                   }).ToListAsync();

        public async Task<ProductDto> GetProductWithOptions(int productDetailId)
        {
            var product = await GetProduct(productDetailId);
            product.ProductOptions = await GetProductOptions(product.ProductDetailId);
            return product;
        }

        public async Task<OperationResult<bool>> CheckProductForAddToBasket(AddProductToBasketCommand addProductToBasketCommand, int quantityOfAlreadyProductInBasket)
        {
            if (_product == null)
                _product = await GetProduct(addProductToBasketCommand.ProductDetailId);

            //Check is the desired product available
            if (_product == null)
                return OperationResult<bool>.Result(false, "Product not found!");

            //Check if the item is in stock
            if (!CheckProductStock(addProductToBasketCommand, quantityOfAlreadyProductInBasket))
                return OperationResult<bool>.Result(false, "Stock is insufficient!");

            //Check does the product have a valid price
            if (!CheckProductPrice())
                return OperationResult<bool>.Result(false, "The requested product price is invalid!");

            return OperationResult<bool>.Result(true, string.Empty);
        }

        private bool CheckProductStock(AddProductToBasketCommand addProductToBasketCommand, int quantityOfAlreadyProductInBasket) =>
            _product.Stock > quantityOfAlreadyProductInBasket + addProductToBasketCommand.Quantity;

        private bool CheckProductPrice() => _product.Price > 0;
    }
}
