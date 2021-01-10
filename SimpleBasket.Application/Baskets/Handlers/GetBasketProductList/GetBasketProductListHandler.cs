using MediatR;
using SimpleBasket.Application.Baskets.Queries.GetBasketProductList;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Baskets.Handlers.GetBasketProductList
{
    public class GetBasketProductListHandler : IRequestHandler<GetBasketProductListQuery, ServiceResult<BasketDto>>
    {
        private readonly IBasketService _basketService;

        public GetBasketProductListHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<ServiceResult<BasketDto>> Handle(GetBasketProductListQuery request, CancellationToken cancellationToken)
        {
            return new ServiceResult<BasketDto>
            {
                Success = true,
                Data = await _basketService.GetBasketProductList(request)
            };
        }
    }
}
