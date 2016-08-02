using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InventoryData
{
	public class Item : ChangeHandlerBase
	{
		private int _ItemNumber;
		/// <summary>
		/// Reference number for this item
		/// </summary>
		public int ItemNumber
		{
			get { return _ItemNumber; }
			set { _ItemNumber = value; NotifyOfPropertyChange(() => ItemNumber); }
		}

		private string _Name;
		/// <summary>
		/// Name of this item
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; NotifyOfPropertyChange(() => Name); }
		}

		private decimal _Cost;
		/// <summary>
		/// The basic cost for this item
		/// </summary>
		public decimal Cost
		{
			get { return _Cost; }
			set { _Cost = value; NotifyOfPropertyChange(() => Cost); }
		}

		private int _QuantityOnHand;
		/// <summary>
		/// The number of items currently on hand in inventory
		/// </summary>
		public int QuantityOnHand
		{
			get { return _QuantityOnHand; }
			set { _QuantityOnHand = value; NotifyOfPropertyChange(() => QuantityOnHand); }
		}

		private ICollection<OrderItem> _OrderItems;
		public virtual ICollection<OrderItem> OrderItems
		{
			get { return _OrderItems; }
			set { _OrderItems = value; NotifyOfPropertyChange(() => OrderItems); }
		}

		public Item()
		{
			OrderItems = new List<OrderItem>();
		}
	}
}
