using System.Collections.Generic;

namespace SimpleBasket.Application.Common.Models
{
    public class BasketDto
    {
        public decimal BasketPrice { get; set; }
        public IList<BasketProduct> Products { get; set; }
    }
}
