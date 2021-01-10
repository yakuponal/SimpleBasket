using MediatR;
using SimpleBasket.Application.Common.Models;

namespace SimpleBasket.Application.Baskets.Commands.AddProductToBasket
{
    public class AddProductToBasketCommand : IRequest<ServiceResult<BasketDto>>
    {
        public int CustomerId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }

        public AddProductToBasketCommand(int customerId, int productDetailId, int quantity)
        {
            CustomerId = customerId;
            ProductDetailId = productDetailId;
            Quantity = quantity;
        }
    }
}
