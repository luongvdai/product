using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Purchase
    {
        public Purchase()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int? ProviderId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? ProductName { get; set; }
        public decimal? SalePrice { get; set; }

        public virtual Provider? Provider { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
