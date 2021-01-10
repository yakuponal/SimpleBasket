using MediatR;
using SimpleBasket.Application.Common.Models;
using System.Collections.Generic;

namespace SimpleBasket.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ServiceResult<IList<ProductDto>>>
    {
    }
}
