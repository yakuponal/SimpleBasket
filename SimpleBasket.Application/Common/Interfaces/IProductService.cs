using SimpleBasket.Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<bool> CheckProductStock(int productDetailId, int quantity);
        Task<ProductDto> GetProduct(int productDetailId);
        Task<IList<ProductOptionDto>> GetProductOptions(int productDetailId);
    }
}
