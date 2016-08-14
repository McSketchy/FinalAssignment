using System;
using System.Collections.Generic;

namespace WpfApplication1.Models
{
    public partial class UserOrder
    {
        public int UserOrderId { get; set; }
        public int UserId { get; set; }
        public int OrderNumber { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
