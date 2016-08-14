using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace WpfApplication1.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderNumber);

            // Properties
            this.Property(t => t.Purchaser)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.DatePlaced).HasColumnName("DatePlaced");
            this.Property(t => t.Purchaser).HasColumnName("Purchaser");
            this.Property(t => t.TotalCost).HasColumnName("TotalCost");
        }
    }
}
