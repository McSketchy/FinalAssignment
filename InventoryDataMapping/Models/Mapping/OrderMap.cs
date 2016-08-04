using InventoryData;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InventoryDataMapping.Models.Mapping
{
	public class OrderMap : EntityTypeConfiguration<Order>
	{
		public OrderMap()
		{
			// Primary Key
			this.HasKey(t => t.OrderNumber);

			// Table & Column Mappings
			this.ToTable("Order");
			this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
			this.Property(t => t.DatePlaced).HasColumnName("DatePlaced");
			this.Property(t => t.TotalCost).HasColumnName("TotalCost");

			this.HasRequired(t => t.Purchaser).WithRequiredDependent().Map(n => n.MapKey("Purchaser"));
		}
	}
}
