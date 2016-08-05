using InventoryData;
using InventoryDataMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataInteraction
{
	public class DatabaseInteraction : IInventoryData, IUserRepository
	{
		public DatabaseInteraction()
		{
		}

		public IEnumerable<Order> GetOrders()
		{
			using(var db = new InventoryContext())
			{
				return (from order in db.Orders.Include("OrderItems")
											   .Include("OrderItems.Item")
											   .Include("Purchaser")
						select order).ToList();
			}
		}

		public IEnumerable<Item> GetItems()
		{
			using (var db = new InventoryContext())
			{
				return (from item in db.Items
						select item).ToList();
			}
		}

		public IEnumerable<OrderItem> GetOrderItems(int orderNumber)
		{
			using (var db = new InventoryContext())
			{
				return (from orderItem in db.OrderItems
						where orderItem.OrderNumber == orderNumber
						select orderItem).ToList();
			}
		}

		public bool SaveOrder(Order order)
		{
			if (order == null)
				return false;

			try
			{
				using (var db = new InventoryContext())
				{
					db.Orders.Add(order);
					db.SaveChanges();
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool SaveItem(Item item)
		{
			if (item == null)
				return false;

			try
			{
				using (var db = new InventoryContext())
				{
					db.Items.Add(item);
					db.SaveChanges();
				}
				return true;
			}
			catch(Exception e)
			{
				return false;
			}
		}

		public bool SaveOrderItem(int orderNumber, OrderItem orderItem)
		{
			if (orderItem == null)
				return false;

			try
			{
				using (var db = new InventoryContext())
				{
					var order = (from o in db.Orders
								 where o.OrderNumber == orderNumber
								 select o).SingleOrDefault();

					if (order == null)
						return false;

					order.OrderItems.Add(orderItem);
					db.OrderItems.Add(orderItem);
					db.SaveChanges();
				}

				return true;
			}
			catch(Exception e)
			{
				return false;
			}
		}

		public IEnumerable<User> GetUsers()
		{
			using (var db = new InventoryContext())
			{
				return (from user in db.Users
						select user).ToList();
			}
		}

		public bool SaveUser(User user)
		{
			if (user == null)
				return false;

			try
			{
				using (var db = new InventoryContext())
				{
					db.Users.Add(user);
					db.SaveChanges();
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public IEnumerable<Order> GetUserOrders(int userId)
		{
			using (var db = new InventoryContext())
			{
				return (from u in db.UserOrders
						where u.UserId == userId
						select u.Order).ToList();
			}
		}


		public Task<IEnumerable<Order>> GetOrdersAsync()
		{
			var factory = new TaskFactory<IEnumerable<Order>>();
			return factory.StartNew(() =>
			{
				return this.GetOrders();
			});
		}

		public Task<IEnumerable<Item>> GetItemsAsync()
		{
			var factory = new TaskFactory<IEnumerable<Item>>();
			return factory.StartNew(() =>
			{
				return GetItems();
			});
		}

		public Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber)
		{
			var factory = new TaskFactory<IEnumerable<OrderItem>>();
			return factory.StartNew(() =>
			{
				return GetOrderItems(orderNumber);
			});
		}

		public Task<bool> SaveOrderAsync(Order order)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveOrder(order);
			});
		}

		public Task<bool> SaveItemAsync(Item item)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveItem(item);
			});
		}

		public Task<bool> SaveOrderItemAsync(int orderNumber, OrderItem orderItem)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveOrderItem(orderNumber, orderItem);
			});
		}

		public Task<IEnumerable<User>> GetUsersAsync()
		{
			return new TaskFactory<IEnumerable<User>>().StartNew(this.GetUsers);
		}

		public Task<bool> SaveUserAsync(User user)
		{
			return new TaskFactory<bool>().StartNew(() => this.SaveUser(user));
		}

		public Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
		{
			return new TaskFactory<IEnumerable<Order>>().StartNew(() => this.GetUserOrders(userId));
		}
	}
}
