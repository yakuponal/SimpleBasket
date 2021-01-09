using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class Option
    {
        public Option()
        {
            ProductOptions = new HashSet<ProductOption>();
        }

        public int OptionId { get; set; }
        public int OptionGroupId { get; set; }
        public string OptionName { get; set; }

        public virtual OptionGroup OptionGroup { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
