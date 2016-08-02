using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace InventoryData
{
	public class UserOrder : ChangeHandlerBase
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int _UserOrderId;
		public int UserOrderId
		{
			get { return _UserOrderId; }
			set { _UserOrderId = value; NotifyOfPropertyChange(() => UserOrderId); }
		}

		private int _UserId;
		public int UserId
		{
			get { return _UserId; }
			set { _UserId = value; NotifyOfPropertyChange(() => UserId); }
		}

		private int _OrderNumber;
		public int OrderNumber
		{
			get { return _OrderNumber; }
			set { _OrderNumber = value; NotifyOfPropertyChange(() => OrderNumber); }
		}

		private User _User;
		public virtual User User
		{
			get { return _User; }
			set { _User = value; NotifyOfPropertyChange(() => User); }
		}

		private Order _Order;
		public virtual Order Order
		{
			get { return _Order; }
			set { _Order = value; NotifyOfPropertyChange(() => Order); }
		}
	}
}
