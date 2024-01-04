using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int ProviderId { get; set; }
        public string? ProviderName { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
