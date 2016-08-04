using InventoryData;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataMapping.Models.Mapping
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			this.HasKey(t => t.UserId);

			this.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(100);
			this.Property(t => t.Address)
				.IsRequired()
				.HasMaxLength(100);
			this.Property(t => t.Phone)
				.IsRequired()
				.HasMaxLength(100);

			this.ToTable("User");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.Name).HasColumnName("Name");
			this.Property(t => t.Address).HasColumnName("Address");
			this.Property(t => t.Phone).HasColumnName("Phone");
		}
	}
}
