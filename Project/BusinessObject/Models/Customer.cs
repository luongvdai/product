using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
