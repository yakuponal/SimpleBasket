using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class ProductOption
    {
        public int ProductOptionId { get; set; }
        public int ProductDetailId { get; set; }
        public int OptionId { get; set; }

        public virtual Option Option { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
