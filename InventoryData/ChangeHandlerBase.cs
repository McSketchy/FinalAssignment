using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InventoryData
{
	/// <summary>
	/// Handles the property change events for notifying items.
	/// </summary>
	public class ChangeHandlerBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyOfPropertyChange<T>(Expression<Func<T>> expression)
		{
			var member = (MemberExpression)expression.Body;
			NotifyOfPropertyChange(member.Member.Name);
		}

		private void NotifyOfPropertyChange(string propertyName)
		{
			var evt = PropertyChanged;
			if (evt != null)
				evt(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
