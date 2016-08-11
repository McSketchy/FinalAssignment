

//I added DisplayMemberPath variable to the Purchaser ComboBox so it would show the Name property
//of the User Objects it was listing. I also did the database hookup for it so you could get an idea
//of how to do it for the other things. Also including a few notes further down to help guide you a bit
//It's all guess work on my end so good luck :P


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
        /*TODO: Add variables/properties for OrderNumber, PurchaseDate, OrderTotal, ItemComboBox
         SelectedPurchaser, SelectedItem, and SelectedNewOrderItems*/

        /* Unsure if these properties are needed or even if they will function as is
         *  
         * private int OrderNumber;
        public int _OrderNumber
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

        private int PurchaseDate;
        public int _PurchaseDate
        {
            get
            {
                return _PurchaseDate;
            }
            set
            {
                _PurchaseDate = value;
                NotifyOfPropertyChange(() => PurchaseDate);
            }
        }

        private int OrderTotal;
        public int _OrderTotal
        {
            get
            {
                return _OrderTotal;
            }
            set
            {
                _OrderTotal = value;
                NotifyOfPropertyChange(() => OrderTotal);
            }
        }

        private String SelectedPurchaser;
        public String _SelectedPurchaser
        {
            get
            {
                return _SelectedPurchaser;
            }
            set
            {
                _SelectedPurchaser = value;
                NotifyOfPropertyChange(() => Purchaser);
            }
        }
        */

        private ObservableCollection<Item> ItemComboBox;
        public ObservableCollection<Item> _ItemComboBox
        {
            get
            {
                return _ItemComboBox;
            }
            set
            {
                _ItemComboBox = value;
                NotifyOfPropertyChange(() => ItemComboBox);
            }
        }

        private Item SelectedItemComboBox;
        public ObservableCollection<Item> _SelectedItemComboBox
        {
            get
            {
                return _SelectedItemComboBox;
            }
            set
            {
                _SelectedItemComboBox = value;
                NotifyOfPropertyChange(() => SelectedItemComboBox);
            }
        }

        public NewOrderViewModel()
        {
            //DatabaseInteraction Object, check InventoryDataInteraction.DatabaseInteraction.cs
            //To see all the available methods for use.
            DatabaseInteraction dbi = new DatabaseInteraction();

            //passing dbi method from above into OCollection COnstructor to populate the collection of users from the database
            Purchaser = new ObservableCollection<User>(dbi.GetUsers());
        }

        public bool CanSave()
        {
            return true; 
        }



        /*TODO: Populate Item ComboBox 
         AddItem onclick method -- Create OrderItem and add to datagrid (OrderNumber from above, quantity 0, cost from item, name from item)
         Add check that Item is selected (save this for the end)
         Set Quantity coluimn as Editable in datagrid
         SaveOrder onclick method -- Add order to database -- Foreach row in datagrid add orderitem to database
         Add check that order can be saved (save this for end too)
         Method to calculate/update Order Total after user changes item quantity
         Thats all I can think of off of the top of my head
         oh, most importantly... Have Fun :P   */
    }
}
