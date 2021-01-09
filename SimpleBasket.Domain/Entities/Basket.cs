using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class Basket
    {
        public int BasketId { get; set; }
        public int CustomerId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
