using InventoryData;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InventoryDataMapping.Models.Mapping
{
	public class OrderItemMap : EntityTypeConfiguration<OrderItem>
	{
		public OrderItemMap()
		{
			// Primary Key
			this.HasKey(t => t.OrderItemNumber);

			// Properties
			// Table & Column Mappings
			this.ToTable("OrderItem");
			this.Property(t => t.OrderItemNumber).HasColumnName("OrderItemNumber");
			this.Property(t => t.Quantity).HasColumnName("Quantity");
			this.Property(t => t.ItemCost).HasColumnName("ItemCost");
			this.Property(t => t.ItemNumber).HasColumnName("ItemNumber");
			this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");

			// Relationships
			this.HasRequired(t => t.Item)
				.WithMany(t => t.OrderItems)
				.HasForeignKey(d => d.ItemNumber);

			this.HasRequired(t => t.Order)
				.WithMany(t => t.OrderItems)
				.HasForeignKey(d => d.OrderNumber);
		}
	}
}
