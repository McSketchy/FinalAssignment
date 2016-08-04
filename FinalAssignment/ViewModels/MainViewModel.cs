using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn;
using Caliburn.Micro;
using System.Diagnostics;

namespace FinalAssignment.ViewModels
{
    class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {

        /// <summary>
        /// Button Click event for Orders Button
        /// Loads the Orders view
        /// </summary>
        public void ShowOrders()
        {
            var ordersVM = IoC.Get<OrdersViewModel>();
            ActivateItem(ordersVM);
        }

        /// <summary>
        /// Button Click event for New Order Button
        /// Loads the New Order view
        /// </summary>
        public void ShowNewOrder()
        {
            var newOrderVM = IoC.Get<NewOrderViewModel>();
            ActivateItem(newOrderVM);
        }

        /// <summary>
        /// Button Click event for Inventory Button
        /// Loads the Inventory view
        /// </summary>
        public void ShowInventory()
        {
            var inventoryVM = IoC.Get<InventoryViewModel>();
            ActivateItem(inventoryVM);
        }

        /// <summary>
        /// Runs when the viewmodel is loaded
        /// </summary>
        protected override void OnActivate()
        {
            base.OnActivate();
            ShowOrders();
        }
    }
}
