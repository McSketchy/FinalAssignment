using InventoryData;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InventoryDataMapping.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemNumber);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Item");
            this.Property(t => t.ItemNumber).HasColumnName("ItemNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.QuantityOnHand).HasColumnName("QuantityOnHand");
        }
    }
}
