using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBasket.Domain.Entities
{
    public partial class OptionGroup
    {
        public OptionGroup()
        {
            Options = new HashSet<Option>();
        }

        public int OptionGroupId { get; set; }
        public string OptionGroupName { get; set; }

        public virtual ICollection<Option> Options { get; set; }
    }
}
