using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Baskets = new HashSet<Basket>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
