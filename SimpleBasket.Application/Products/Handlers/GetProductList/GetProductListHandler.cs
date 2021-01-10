using MediatR;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Common.Models;
using SimpleBasket.Application.Products.Queries.GetProductList;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Products.Handlers.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, ServiceResult<IList<ProductDto>>>
    {
        private readonly IProductService _productService;

        public GetProductListHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult<IList<ProductDto>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return new ServiceResult<IList<ProductDto>>
            {
                Success = true,
                Data = await _productService.GetProducts()
            };
        }
    }
}
