using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleBasket.Application.Baskets.Commands.AddProductToBasket;
using SimpleBasket.Application.Baskets.Queries.GetBasketProductList;
using SimpleBasket.Application.Common.Models;
using System.Net;
using System.Threading.Tasks;

namespace SimpleBasket.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<ServiceResult<BasketDto>> GetBasketProductList(int customerId)
        {
            var basket = await _mediator.Send(new GetBasketProductListQuery(customerId));

            if (basket != null && basket.Data == null)
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;

            return basket;
        }

        [HttpPost]
        public async Task<ServiceResult<BasketDto>> AddProductToBasket([FromBody] AddProductToBasketCommand addProductToBasketCommand)
        {
            var basket = await _mediator.Send(addProductToBasketCommand);

            this.HttpContext.Response.StatusCode = basket != null && basket.Data == null ? (int)HttpStatusCode.Forbidden : (int)HttpStatusCode.Created;

            return basket;
        }
    }
}
