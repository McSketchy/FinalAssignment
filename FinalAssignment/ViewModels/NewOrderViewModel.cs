







/*TODO: 
 * Finish CanSaveOrder property
 * Finish UpdateOrderTotal method
 * Test SaveOrder Mehtod
 * Make it Pretty
 */






using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryData;
using InventoryDataInteraction;
using System.Collections.ObjectModel;

namespace FinalAssignment.ViewModels
{
    class NewOrderViewModel : Screen, INotifyPropertyChangedEx
    {
        // Private variable with corresopnding public property
        private ObservableCollection<User> _Purchaser;
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

        //Property to initially set the Order Number to be used for this order
        private int _OrderNumber;
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

        //Property to initially set the Purchase Date to be used for this order
        private DateTime _PurchaseDate;
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
        
        private decimal _OrderTotal;
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

        private User _SelectedPurchaser;
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

        private ObservableCollection<Item> _ItemComboBox;
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

        private Item _SelectedItemComboBox;
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

        //Constructor
        public NewOrderViewModel()
        {
            //DatabaseInteraction Object, check InventoryDataInteraction.DatabaseInteraction.cs
            //To see all the available methods for use.
            DatabaseInteraction dbi = new DatabaseInteraction();

            //passing dbi method from above into OCollection COnstructor to populate the collection of users/items from the database
            Purchaser = new ObservableCollection<User>(dbi.GetUsers());
            ItemComboBox = new ObservableCollection<Item>(dbi.GetItems());

            //Set PurchaseDate at start as current date
            PurchaseDate = DateTime.Today;

            //Set order number to 1 greater than last order number
            GetOrderNumber();

            //OrderTotal defaults to $0.00
            OrderTotal = 0.0M;

            NewOrderItems = new ObservableCollection<OrderItem>();
        }

        public void GetOrderNumber()
        {
            DatabaseInteraction dbi = new DatabaseInteraction();
            List<Order> orders = new List<Order>(dbi.GetOrders());

            var orderNum = (from order in orders
                            select order.OrderNumber).Last();


            OrderNumber = orderNum + 1;

        }

        private ObservableCollection<OrderItem> _NewOrderItems;
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

        //this acts as ICommand CanExecute
        public bool CanAddItem
        {
            get
            {
                return !(SelectedItemComboBox == null);
            }
        }

        //this acts as ICommand onclick method
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

        public bool CanSaveOrder
        {
            get
            {
                if (SelectedPurchaser != null && PurchaseDate != null && OrderTotal != 0.0M)
                {
                    return true;
                }
                return false;
            }
        }

        //100% Untested save command
        public void SaveOrder()
        {
            DatabaseInteraction dbi = new DatabaseInteraction();

            Order ord = new Order();
            ord.OrderNumber = OrderNumber;
            ord.Purchaser = SelectedPurchaser;
            UpdateOrderTotal();
            ord.TotalCost = OrderTotal;
            foreach(OrderItem oi in NewOrderItems)
            {
                ord.OrderItems.Add(oi);
            }

            dbi.SaveOrder(ord);
        }

        public void UpdateOrderTotal()
        {
            OrderTotal = 0.0M;

            foreach(OrderItem oi in NewOrderItems)
            {
                OrderTotal += (oi.Quantity * oi.ItemCost);
            }

            /*  Hurray for learning!
            
            var itemCosts =
                from i in NewOrderItems
                select i.ItemCost;

            var itemQty =
                from i in NewOrderItems
                select i.Quantity;

            List<decimal> tempCost = new List<decimal>();
            int myIndex = 0;
            foreach (var i in itemCosts)
            {
                tempCost.Add(i);
            }

            tempCost.ToArray();

            foreach (var j in itemQty)
            {
                decimal tempQty = j;
                OrderTotal += tempCost[myIndex] * tempQty;
                myIndex++;
            }
            
             */
        }
    }
}
