using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace InventoryData
{
	[DataContract]
	public class User : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int _UserId;
		[DataMember]
		public int UserId
		{
			get { return _UserId; }
			set { _UserId = value; NotifyOfPropertyChange(() => UserId); }
		}

		private string _Name;
		[DataMember]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; NotifyOfPropertyChange(() => Name); }
		}

		private string _Address;
		[DataMember]
		public string Address
		{
			get { return _Address; }
			set { _Address = value; NotifyOfPropertyChange(() => Address); }
		}

		private string _Phone;
		[DataMember]
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; NotifyOfPropertyChange(() => Phone); }
		}


		private ICollection<UserOrder> _UserOrders;
		[DataMember]
		public virtual ICollection<UserOrder> UserOrders
		{
			get { return _UserOrders; }
			set { _UserOrders = value; }
		}

		protected void NotifyOfPropertyChange(string propertyName)
		{
			var e = PropertyChanged;
			if (e != null)
				e(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void NotifyOfPropertyChange<T>(Expression<Func<T>> expression)
		{
			var member = (MemberExpression)expression.Body;
			NotifyOfPropertyChange(member.Member.Name);
		}
	}
}
