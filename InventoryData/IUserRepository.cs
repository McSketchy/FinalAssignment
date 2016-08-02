using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers();
		bool SaveUser(User user);
		IEnumerable<Order> GetUserOrders(int userId);

		Task<IEnumerable<User>> GetUsersAsync();
		Task<bool> SaveUserAsync(User user);
		Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
	}
}
