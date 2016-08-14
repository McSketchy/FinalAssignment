using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace WpfApplication1.Models.Mapping
{
    public class UserOrderMap : EntityTypeConfiguration<UserOrder>
    {
        public UserOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.UserOrderId);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserOrder");
            this.Property(t => t.UserOrderId).HasColumnName("UserOrderId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.UserOrders)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserOrders)
                .HasForeignKey(d => d.UserId);

        }
    }
}
