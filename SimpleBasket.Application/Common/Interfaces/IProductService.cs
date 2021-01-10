using SimpleBasket.Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int productDetailId);
        Task<ProductDto> GetProductWithOptions(int productDetailId);
        Task<IList<ProductOptionDto>> GetProductOptions(int productDetailId);
        Task<bool> CheckProductForAddToBasket(int productDetailId, int quantity);
    }
}
