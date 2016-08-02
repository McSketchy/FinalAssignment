using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryData
{
	public class Order : ChangeHandlerBase
	{
		private int _OrderNumber;
		/// <summary>
		/// Reference number for this order
		/// </summary>
		public int OrderNumber
		{
			get { return _OrderNumber; }
			set { _OrderNumber = value; NotifyOfPropertyChange(() => OrderNumber); }
		}

		private DateTime _DatePlaced;
		/// <summary>
		/// The date and time this order was placed
		/// </summary>
		public DateTime DatePlaced
		{
			get { return _DatePlaced; }
			set { _DatePlaced = value; NotifyOfPropertyChange(() => DatePlaced); }
		}

		private User _Purchaser;
		/// <summary>
		/// The identifier of the person/company/entity placing the order
		/// </summary>
		public User Purchaser
		{
			get { return _Purchaser; }
			set { _Purchaser = value; NotifyOfPropertyChange(() => Purchaser); }
		}

		private decimal _TotalCost;
		public decimal TotalCost
		{
			get { return _TotalCost; }
			set { _TotalCost = value; NotifyOfPropertyChange(() => TotalCost); }
		}

		private ICollection<OrderItem> _OrderItems;
		/// <summary>
		/// Collection of order items purchased in this order
		/// </summary>
		public virtual ICollection<OrderItem> OrderItems
		{
			get { return _OrderItems; }
			set { _OrderItems = value; NotifyOfPropertyChange(() => OrderItems); }
		}

		private ICollection<UserOrder> _UserOrders;
		public virtual ICollection<UserOrder> UserOrders
		{
			get { return _UserOrders; }
			set { _UserOrders = value; NotifyOfPropertyChange(() => UserOrders); }
		}

		public Order()
		{
			OrderItems = new List<OrderItem>();
		}
	}
}
