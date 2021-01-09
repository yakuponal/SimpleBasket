using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
