using InventoryData;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataMapping.Models.Mapping
{
	public class UserOrderMap : EntityTypeConfiguration<UserOrder>
	{
		public UserOrderMap()
		{
			this.HasKey(t => t.UserOrderId);

			this.ToTable("UserOrder");
			this.Property(t => t.UserOrderId).HasColumnName("UserOrderId");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");

			this.HasRequired(t => t.Order)
				.WithMany(t => t.UserOrders)
				.HasForeignKey(t => t.OrderNumber);

			this.HasRequired(t => t.User)
				.WithMany(t => t.UserOrders)
				.HasForeignKey(t => t.UserId);
		}
	}
}
