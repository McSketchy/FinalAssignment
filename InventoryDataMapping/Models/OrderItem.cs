using System;
using System.Collections.Generic;

namespace InventoryDataMapping.Models
{
    public partial class OrderItem
    {
        public int OrderItemNumber { get; set; }
        public short Quantity { get; set; }
        public decimal ItemCost { get; set; }
        public int ItemNumber { get; set; }
        public int OrderNumber { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
