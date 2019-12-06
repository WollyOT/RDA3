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

        public AppViewModel()
        {
            OrderVM = new OrderLandingViewModel();
            SalesRecordVM = new SalesRecordLandingViewModel();

           // CustomerVM = new CustomerViewModel();
          //  InventoryVM = new InventoryViewModel();

            CurrentView = OrderVM;

            LoadOrderCommand = new RelayCommand(LoadOrder);
            LoadSalesRecordsCommand = new RelayCommand(LoadSalesRecords);
            LoadInventoryCommand = new RelayCommand(LoadInventory);

        }

        private void LoadOrder()
        {
            CurrentView = OrderVM;

        }

        private void LoadSalesRecords()
        {
            CurrentView = SalesRecordVM;
        }

        private void LoadInventory()
        {
            CurrentView = InventoryVM;
        }
    }
}
