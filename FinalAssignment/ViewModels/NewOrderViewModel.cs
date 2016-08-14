using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryData;
using InventoryDataInteraction;
using System.Collections.ObjectModel;
using System.Windows;

namespace FinalAssignment.ViewModels
{
    class NewOrderViewModel : Screen, INotifyPropertyChangedEx
    {
        #region variables
        private ObservableCollection<User> _Purchaser;
        private int _OrderNumber;
        private DateTime _PurchaseDate;
        private decimal _OrderTotal;
        private User _SelectedPurchaser;
        private ObservableCollection<Item> _ItemComboBox;
        private Item _SelectedItemComboBox;
        private ObservableCollection<OrderItem> _NewOrderItems;
        #endregion

        #region properties
        public ObservableCollection<User> Purchaser
        {
            get
            {
                return _Purchaser;
            }
            set
            {
                _Purchaser = value;
                NotifyOfPropertyChange(() => Purchaser);
            }
        }
        public int OrderNumber
        {
            get
            {
                return _OrderNumber;
            }
            set
            {
                _OrderNumber = value;
                NotifyOfPropertyChange(() => OrderNumber);
            }
        }
        public DateTime PurchaseDate
        {
            get
            {
                return _PurchaseDate;
            }
            set
            {
                _PurchaseDate = value;
                NotifyOfPropertyChange(() => PurchaseDate);
                NotifyOfPropertyChange(() => CanSaveOrder);
            }
        }
        public decimal OrderTotal
        {
            get
            {
                return _OrderTotal;
            }
            set
            {
                _OrderTotal = value;
                NotifyOfPropertyChange(() => OrderTotal);
                NotifyOfPropertyChange(() => CanSaveOrder);
            }
        }
       public User SelectedPurchaser
        {
            get
            {
                return _SelectedPurchaser;
            }
            set
            {
                _SelectedPurchaser = value;
                NotifyOfPropertyChange(() => Purchaser);
                NotifyOfPropertyChange(() => CanSaveOrder);
            }
        }
        public ObservableCollection<Item> ItemComboBox
        {
            get
            {
                return _ItemComboBox;
            }
            set
            {
                _ItemComboBox = value;
                NotifyOfPropertyChange(() => ItemComboBox);
                NotifyOfPropertyChange(() => CanAddItem);
            }
        }
        public Item SelectedItemComboBox
        {
            get
            {
                return _SelectedItemComboBox;
            }
            set
            {
                _SelectedItemComboBox = value;
                NotifyOfPropertyChange(() => SelectedItemComboBox);
                NotifyOfPropertyChange(() => CanAddItem);
            }
        }
        public ObservableCollection<OrderItem> NewOrderItems
        {
            get
            {
                return _NewOrderItems;
            }
            set
            {
                _NewOrderItems = value;
                NotifyOfPropertyChange(() => NewOrderItems);
            }
        }
        public bool CanAddItem
        {
            get
            {
                return !(SelectedItemComboBox == null);
            }
        }
        public bool CanSaveOrder
        {
            get
            {
                if (NewOrderItems == null)
                {
                    return false;
                }
                if (SelectedPurchaser != null && PurchaseDate != null && OrderTotal != 0.0M && NewOrderItemsValid())
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region constructors
        public NewOrderViewModel()
        {
            DatabaseInteraction dbi = new DatabaseInteraction();
            Purchaser = new ObservableCollection<User>(dbi.GetUsers());
            ItemComboBox = new ObservableCollection<Item>(dbi.GetItems());
            NewOrderItems = new ObservableCollection<OrderItem>();
            PurchaseDate = DateTime.Today;
            GetOrderNumber();
            OrderTotal = 0.0M;
        }
        #endregion

        #region methods
        /// <summary>
        /// Retrieves the last used OrerNumber from the Orders table in the database
        /// Set the OrderNumber property to the next available OrderNumber
        /// </summary>
        public void GetOrderNumber()
        {
            DatabaseInteraction dbi = new DatabaseInteraction();
            List<Order> orders = new List<Order>(dbi.GetOrders());

            try
            {
                var orderNum = (from order in orders
                                select order.OrderNumber).Last();

                OrderNumber = orderNum + 1;
            }
            catch (Exception e)
            {

                OrderNumber = 1;
            }
            //var orderNum = (from order in orders
            //                select order.OrderNumber).Last();

            //OrderNumber = orderNum + 1;
        }
        /// <summary>
        /// Adds a new Item to the current Order
        /// </summary>
        public void AddItem()
        {
            OrderItem tempAdd = new OrderItem();

            tempAdd.OrderNumber = OrderNumber;
            tempAdd.Item = SelectedItemComboBox;
            tempAdd.ItemNumber = SelectedItemComboBox.ItemNumber;
            tempAdd.ItemCost = SelectedItemComboBox.Cost * 1.15M;
            tempAdd.Quantity = 1;
            NewOrderItems.Add(tempAdd);
            SelectedItemComboBox = null;
            UpdateOrderTotal();
        }
        /// <summary>
        /// Saves the current Order to the database
        /// </summary>
        public void SaveOrder()
        {
            DatabaseInteraction dbi = new DatabaseInteraction();

            Order ord = new Order();
            ord.DatePlaced = PurchaseDate;
            ord.OrderNumber = OrderNumber;
            ord.Purchaser = SelectedPurchaser;
            ord.TotalCost = OrderTotal;
            foreach(OrderItem oi in NewOrderItems)
            {
                ord.OrderItems.Add(oi);
            }

            dbi.SaveOrder(ord);
            MessageBox.Show("Order Has Been Saved", "Save Order");
            ClearNewOrderView();
        }
        /// <summary>
        /// Resets the OrderView for use in the next order
        /// </summary>
        public void ClearNewOrderView()
        {
            GetOrderNumber();
            PurchaseDate = DateTime.Today;
            OrderTotal = 0.0M;
            SelectedPurchaser = null;
            NewOrderItems = new ObservableCollection<OrderItem>();
        }
        /// <summary>
        /// Validates that all fields in the OrderItem Datagrid ahve been populated correctly
        /// </summary>
        /// <returns></returns>
        public bool NewOrderItemsValid()
        {
            foreach(OrderItem oi in NewOrderItems)
            {
                if (oi.Quantity <= 0 || oi.ItemCost <= 0)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Updates the total cost of the order
        /// </summary>
        public void UpdateOrderTotal()
        {
            OrderTotal = 0.0M;

            foreach(OrderItem oi in NewOrderItems)
            {
                OrderTotal += (oi.Quantity * oi.ItemCost);
            }
        }
        #endregion
    }
}
