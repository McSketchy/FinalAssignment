using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData
{
	public interface IInventoryData
	{
		/// <summary>
		/// Retrieves all orders from the database
		/// </summary>
		/// <remarks>
		/// You will need to have this method populate all of the order items as well for them to show up.
		/// You should also have the method populate the individual items for each order as well.
		/// </remarks>
		IEnumerable<Order> GetOrders();
		/// <summary>
		/// Retrieves all item records from the database
		/// </summary>
		/// <returns></returns>
		IEnumerable<Item> GetItems();
		/// <summary>
		/// Retrieves all order items for the given order
		/// </summary>
		/// <param name="orderNumber">The id number for the order to which these order items belong</param>
		/// <remarks>You will need to populate the item records for each order item as well</remarks>
		IEnumerable<OrderItem> GetOrderItems(int orderNumber);

		/// <summary>
		/// Saves the given order to the database
		/// </summary>
		/// <param name="order" cref="InventoryData.Order">Order to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		bool SaveOrder(Order order);
		/// <summary>
		/// Saves the given item to the database
		/// </summary>
		/// <param name="item" cref="InventoryData.Item">Item to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		bool SaveItem(Item item);
		/// <summary>
		/// Save the given order item to the database under the specified order
		/// </summary>
		/// <param name="orderNumber">Id number for the Order record this order item belongs to</param>
		/// <param name="orderItem">OrderItem to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		bool SaveOrderItem(int orderNumber, OrderItem orderItem);

		/// <summary>
		/// Asyncronously retrieves all orders from the database
		/// </summary>
		/// <remarks>
		/// You will need to have this method populate all of the order items as well for them to show up.
		/// You should also have the method populate the individual items for each order as well.
		/// </remarks>
		Task<IEnumerable<Order>> GetOrdersAsync();
		/// <summary>
		/// Asyncronously retrieves all item records from the database
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Item>> GetItemsAsync();
		/// <summary>
		/// Asyncronously retrieves all order items for the given order
		/// </summary>
		/// <param name="orderNumber">The id number for the order to which these order items belong</param>
		/// <remarks>You will need to populate the item records for each order item as well</remarks>
		Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber);

		/// <summary>
		/// Asyncronously saves the given order to the database
		/// </summary>
		/// <param name="order" cref="InventoryData.Order">Order to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		Task<bool> SaveOrderAsync(Order order);
		/// <summary>
		/// Asyncronously saves the given item to the database
		/// </summary>
		/// <param name="item" cref="InventoryData.Item">Item to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		Task<bool> SaveItemAsync(Item item);
		/// <summary>
		/// Asyncronously saves the given order item to the database under the specified order
		/// </summary>
		/// <param name="orderNumber">Id number for the Order record this order item belongs to</param>
		/// <param name="orderItem">OrderItem to be saved</param>
		/// <returns>Whether or not the save was successful</returns>
		Task<bool> SaveOrderItemAsync(int orderNumber, OrderItem orderItem);
	}
}
