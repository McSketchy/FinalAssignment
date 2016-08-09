using Caliburn.Micro;
using InventoryData;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryDataInteraction;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Screen, INotifyPropertyChangedEx
    {
        private Order _SelectedOrders;
        public Order SelectedOrders
        {
            get
            {
                return _SelectedOrders;
            }
            set
            {
                _SelectedOrders = value;
                NotifyOfPropertyChange(() => SelectedOrders);
            }
        }
        private ObservableCollection<Order> _Orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
                NotifyOfPropertyChange(() => Orders);
            }
        }

        public OrdersViewModel()
        {
            //DatabaseInteraction dbi = new DatabaseInteraction();
            //Orders = new ObservableCollection<Order>(dbi.GetOrders());
            generateTempData();
        }

        #region tempData
        /// <summary>
        /// creates temporary data for testing purposes
        /// </summary>
        public void generateTempData()
        {
            Item iA = new Item();
            iA.ItemNumber = 1001;
            iA.Name = "Banana";
            iA.Cost = 32.5M;
            iA.QuantityOnHand = 16312;

            Item iB = new Item();
            iB.ItemNumber = 1253;
            iB.Name = "Wrench";
            iB.Cost = 52.34M;
            iB.QuantityOnHand = 84;

            Item iC = new Item();
            iC.ItemNumber = 9739;
            iC.Name = "Scooter";
            iC.Cost = 2435.99M;
            iC.QuantityOnHand = 11;

            Item iD = new Item();
            iD.ItemNumber = 3254;
            iD.Name = "Pickle";
            iD.Cost = 0.12M;
            iD.QuantityOnHand = 31;

            Item iE = new Item();
            iE.ItemNumber = 4365;
            iE.Name = "Star Wars: Phantom Menace (Blu-Ray)";
            iE.Cost = 0.01M;
            iE.QuantityOnHand = 762938;

            OrderItem oiA = new OrderItem();
            oiA.OrderNumber = 999;
            oiA.Quantity = 2;
            oiA.Item = iA;
            oiA.ItemCost = 2.99M;

            OrderItem oiB = new OrderItem();
            oiB.OrderNumber = 943;
            oiB.Quantity = 7;
            oiB.Item = iB;
            oiB.ItemCost = 14.99M;

            OrderItem oiC = new OrderItem();
            oiC.OrderNumber = 456;
            oiC.Quantity = 17;
            oiC.Item = iC;
            oiC.ItemCost = 2435.99M;

            OrderItem oiD = new OrderItem();
            oiD.OrderNumber = 123;
            oiD.Quantity = 7;
            oiD.Item = iD;
            oiD.ItemCost = 500.00M;

            OrderItem oiE = new OrderItem();
            oiE.OrderNumber = 959;
            oiE.Quantity = 300;
            oiE.Item = iE;
            oiE.ItemCost = 25.99M;

            User uA = new User();
            uA.Name = "Matt Damon";

            User uB = new User();
            uB.Name = "Tommy Lee Jones";

            User uC = new User();
            uC.Name = "Julia Stiles";

            Order oA = new Order();
            oA.OrderNumber = 98764;
            oA.DatePlaced = new DateTime(2016, 1, 1);
            oA.Purchaser = uA;
            oA.OrderItems.Add(oiA);
            oA.OrderItems.Add(oiB);
            oA.OrderItems.Add(oiC);
            oA.TotalCost = 0;
            foreach (OrderItem oi in oA.OrderItems)
            {
                oA.TotalCost += oi.Quantity * oi.Item.Cost;
            }

            Order oB = new Order();
            oB.OrderNumber = 23975;
            oB.DatePlaced = new DateTime(2016, 1, 10);
            oB.Purchaser = uB;
            oB.OrderItems.Add(oiA);
            oB.OrderItems.Add(oiD);
            oB.OrderItems.Add(oiE);
            oB.TotalCost = 0;
            foreach (OrderItem oi in oB.OrderItems)
            {
                oB.TotalCost += oi.Quantity * oi.Item.Cost;
            }

            Order oC = new Order();
            oC.OrderNumber = 72309;
            oC.DatePlaced = new DateTime(2016, 4, 13);
            oC.Purchaser = uC;
            oC.OrderItems.Add(oiE);
            oC.OrderItems.Add(oiC);
            oC.TotalCost = 0;
            foreach (OrderItem oi in oC.OrderItems)
            {
                oC.TotalCost += oi.Quantity * oi.Item.Cost;
            }

            Orders = new ObservableCollection<Order>();
            Orders.Add(oA);
            Orders.Add(oB);
            Orders.Add(oC);
        }
        #endregion
    }
}