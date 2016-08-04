using System;
using System.Collections.Generic;

namespace InventoryDataMapping.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public int OrderNumber { get; set; }
        public System.DateTime DatePlaced { get; set; }
        public string Purchaser { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
