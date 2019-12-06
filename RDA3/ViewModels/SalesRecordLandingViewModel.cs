using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RDA3.ViewModels
{
    public class SalesRecordLandingViewModel : ObservableObject
    {
        private CustomerViewModel _customersVM;
        public CustomerViewModel CustomersVM
        {
            get { return _customersVM; }
            set { OnPropertyChanged(ref _customersVM, value); }
        }
        
        private CartViewModel _cartVM;
        public CartViewModel CartVM
        {
            get { return _cartVM; }
            set { OnPropertyChanged(ref _cartVM, value); }
        }

        public ICommand calculateTotalCommand { get; private set; }


        /// <summary>
        /// Constructor that instantiates a new instance of the OrderViewModel class
        /// </summary>
        public SalesRecordLandingViewModel()
        {

            CustomersVM = new CustomerViewModel();
            CartVM = new CartViewModel();

        }
    }
}
