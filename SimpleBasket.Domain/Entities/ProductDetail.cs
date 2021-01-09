using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            Baskets = new HashSet<Basket>();
            ProductOptions = new HashSet<ProductOption>();
        }

        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductDetailName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
