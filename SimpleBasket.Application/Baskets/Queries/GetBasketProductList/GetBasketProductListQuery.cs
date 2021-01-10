using MediatR;
using SimpleBasket.Application.Common.Models;

namespace SimpleBasket.Application.Baskets.Queries.GetBasketProductList
{
    public class GetBasketProductListQuery : IRequest<ServiceResult<BasketDto>>
    {
        public int CustomerId { get; set; }

        public GetBasketProductListQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
