using MediatR;
using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Baskets.Handlers.AddProductToBasket
{
    public class AddProductToBasketHandler : IRequestHandler<AddProductToBasketCommand, ServiceResult<BasketDto>>
    {
        private readonly IBasketService _basketService;

        public AddProductToBasketHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<ServiceResult<BasketDto>> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.AddProductToBasket(request);

            return new ServiceResult<BasketDto>
            {
                Success = basket != null,
                Data = basket
            };
        }
    }
}
