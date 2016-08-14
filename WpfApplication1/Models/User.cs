using System;
using System.Collections.Generic;

namespace WpfApplication1.Models
{
    public partial class User
    {
        public User()
        {
            this.UserOrders = new List<UserOrder>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
