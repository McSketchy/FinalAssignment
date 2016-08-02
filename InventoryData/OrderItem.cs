using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryData
{
	public class OrderItem : ChangeHandlerBase
	{
		private int _OrderItemNumber;
		/// <summary>
		/// Reference number for the item in the order
		/// </summary>
		public int OrderItemNumber
		{
			get { return _OrderItemNumber; }
			set { _OrderItemNumber = value; NotifyOfPropertyChange(() => OrderItemNumber); }
		}

		private short _Quantity;
		/// <summary>
		/// The number of items in this order
		/// </summary>
		public short Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; NotifyOfPropertyChange(() => Quantity); }
		}

		private decimal _ItemCost;
		/// <summary>
		/// The cost for each item in this line
		/// </summary>
		public decimal ItemCost
		{
			get { return _ItemCost; }
			set { _ItemCost = value; NotifyOfPropertyChange(() => ItemCost); }
		}

		private int _OrderNumber;
		public int OrderNumber
		{
			get { return _OrderNumber; }
			set { _OrderNumber = value; NotifyOfPropertyChange(() => OrderNumber); }
		}

		private int _ItemNumber;
		public int ItemNumber
		{
			get { return _ItemNumber; }
			set { _ItemNumber = value; NotifyOfPropertyChange(() => ItemNumber); }
		}

		private Item _Item;
		/// <summary>
		/// The item that belongs to this order item record
		/// </summary>
		public virtual Item Item
		{
			get { return _Item; }
			set { _Item = value; NotifyOfPropertyChange(() => Item); }
		}

		private Order _Order;
		/// <summary>
		/// The order this order item belongs to
		/// </summary>
		public virtual Order Order
		{
			get { return _Order; }
			set { _Order = value; NotifyOfPropertyChange(() => Order); }
		}
	}
}
