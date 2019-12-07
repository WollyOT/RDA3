/*
* FILE          :   AppViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the landing view of the program.
*                   Instantiates other views so that they remain 
*                   active while operating within the program.
*/
using RDA3.Utilities;
using RDA3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RDA3
{
    public class AppViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private OrderLandingViewModel _orderVM;
        public OrderLandingViewModel OrderVM
        {
            get { return _orderVM; }
            set { OnPropertyChanged(ref _orderVM, value); }
        }

        private SalesRecordLandingViewModel _salesRecordVM;
        public SalesRecordLandingViewModel SalesRecordVM
        {
            get { return _salesRecordVM; }
            set { OnPropertyChanged(ref _salesRecordVM, value); }
        }

        private InventoryViewModel _inventoryVM;
        public InventoryViewModel InventoryVM
        {
            get { return _inventoryVM; }
            set { OnPropertyChanged(ref _inventoryVM, value); }
        }

        public ICommand LoadOrderCommand { get; private set; }
        public ICommand LoadSalesRecordsCommand { get; private set; }
        public ICommand LoadInventoryCommand { get; private set; }

        /*
        * NAME      :   AppViewModel
        * PURPOSE	:   Constructor for the AppViewModel class. Instantiates instances
        *               of other primary viewmodels in necessary for the operations
        *               of the POS app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public AppViewModel()
        {
            OrderVM = new OrderLandingViewModel();
            SalesRecordVM = new SalesRecordLandingViewModel();

            CurrentView = OrderVM; // Order view is the default view of the application

            LoadOrderCommand = new RelayCommand(LoadOrder);
            LoadSalesRecordsCommand = new RelayCommand(LoadSalesRecords);
            LoadInventoryCommand = new RelayCommand(LoadInventory);
        }

        /*
        * NAME      :   LoadOrder
        * PURPOSE	:   Switches the active view of the application to the
        *               Order view.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        private void LoadOrder()
        {
            CurrentView = OrderVM;

        }

        /*
        * NAME      :   LoadSalesRecords
        * PURPOSE	:   Switches the active view of the application to the
        *               SalesRecords view.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        private void LoadSalesRecords()
        {
            CurrentView = SalesRecordVM;
        }

        /*
        * NAME      :   LoadInventory
        * PURPOSE	:   Switches the active view of the application to the
        *               Inventory view.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        private void LoadInventory()
        {
            CurrentView = InventoryVM;
        }
    }
}
