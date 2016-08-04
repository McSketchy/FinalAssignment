using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using InventoryDataMapping.Models.Mapping;
using InventoryData;

namespace InventoryDataMapping.Models
{
	public partial class InventoryContext : DbContext
	{
		static InventoryContext()
		{
			Database.SetInitializer<InventoryContext>(null);
		}

		public InventoryContext()
			: base("Name=InventoryContext")
		{
		}

		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserOrder> UserOrders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ItemMap());
			modelBuilder.Configurations.Add(new OrderMap());
			modelBuilder.Configurations.Add(new OrderItemMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new UserOrderMap());
		}
	}
}
