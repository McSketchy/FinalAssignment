using Caliburn.Micro;
using InventoryData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.ViewModels
{
    class InventoryViewModel : Screen, INotifyPropertyChangedEx
    {
        private ObservableCollection<Item> _Items;

        public ObservableCollection<Item> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        public InventoryViewModel()
        {
            generateTempData();
        }

        #region fakeData

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

            Items = new ObservableCollection<Item>();
            Items.Add(iA);
            Items.Add(iB);
            Items.Add(iC);
            Items.Add(iD);
            Items.Add(iE);
        }
        #endregion
    }
}


