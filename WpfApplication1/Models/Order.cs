using System;
using System.Collections.Generic;

namespace WpfApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
            this.UserOrders = new List<UserOrder>();
        }

        public int OrderNumber { get; set; }
        public System.DateTime DatePlaced { get; set; }
        public string Purchaser { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
