using System.Collections.Generic;

namespace SimpleBasket.Application.Common.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int ProductDetailId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetailName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IList<ProductOptionDto> ProductOptions { get; set; }
    }
}
