using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleBasket.Application.Common.Models;
using SimpleBasket.Application.Products.Queries.GetProductList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBasket.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ServiceResult<IList<ProductDto>>> GetProducts()
        {
            return await _mediator.Send(new GetProductListQuery());
        }
    }
}
