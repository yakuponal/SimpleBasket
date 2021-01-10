using Microsoft.EntityFrameworkCore;
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

        public ProductService(ISimpleBasketDbContext simpleBasketDbContext)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
        }

        public async Task<bool> CheckProductStock(int productDetailId, int quantity)
        {
            var product = await GetProduct(productDetailId);
            return product.Stock - quantity > 0;
        }

        public async Task<ProductDto> GetProduct(int productDetailId)
        {
            var product = await _simpleBasketDbContext.ProductDetails.Where(x => x.ProductDetailId == productDetailId)
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

            product.ProductOptions = await GetProductOptions(product.ProductDetailId);

            return product;
        }

        public async Task<IList<ProductOptionDto>> GetProductOptions(int productDetailId)
        {
            return await (from productOption in _simpleBasketDbContext.ProductOptions.Where(x => x.ProductDetailId == productDetailId)
                          join option in _simpleBasketDbContext.Options on productOption.OptionId equals option.OptionId
                          join optionGroup in _simpleBasketDbContext.OptionGroups on option.OptionGroupId equals optionGroup.OptionGroupId
                          select new ProductOptionDto
                          {
                              OptionGroupId = optionGroup.OptionGroupId,
                              OptionId = option.OptionId,
                              OptionGroupName = optionGroup.OptionGroupName,
                              OptionName = option.OptionName
                          }).ToListAsync();
        }
    }
}
