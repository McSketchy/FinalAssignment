using System;
using System.Collections.Generic;

namespace InventoryDataMapping.Models
{
    public partial class Item
    {
        public Item()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int QuantityOnHand { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
