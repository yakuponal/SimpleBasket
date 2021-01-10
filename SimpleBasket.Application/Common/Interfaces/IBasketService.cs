using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Baskets.Queries.GetBasketProductList;
using SimpleBasket.Application.Common.Models;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Common.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketProductList(GetBasketProductListQuery getBasketProductListQuery);
        Task<OperationResult<BasketDto>> AddProductToBasket(AddProductToBasketCommand addProductToBasketCommand);
        Task<int> GetQuantityOfProductInBasket(int customerId, int productDetailId);
    }
}
