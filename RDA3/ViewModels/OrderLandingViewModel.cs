using RDA3.Models;
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RDA3.ViewModels
{
    public class OrderLandingViewModel : ObservableObject
    {
        private OrderViewModel _ordersVM;
        public OrderViewModel OrdersVM
        {
            get { return _ordersVM; }
            set { OnPropertyChanged(ref _ordersVM, value); }
        }

        private CustomerViewModel _customersVM;
        public CustomerViewModel CustomersVM
        {
            get { return _customersVM; }
            set { OnPropertyChanged(ref _customersVM, value); }
        }
        private ProductViewModel _productsVM;
        public ProductViewModel ProductsVM
        {
            get { return _productsVM; }
            set { OnPropertyChanged(ref _productsVM, value); }
        }
        private CartViewModel _cartVM;
        public CartViewModel CartVM
        {
            get { return _cartVM; }
            set { OnPropertyChanged(ref _cartVM, value); }
        }

        private BranchViewModel _branchVM;
        public BranchViewModel BranchVM
        {
            get { return _branchVM; }
            set { OnPropertyChanged(ref _branchVM, value); }
        }

        private double _total = 0;
        public double Total
        {
            get { return _total; }
            set { OnPropertyChanged(ref _total, value); }
        }

        public ICommand calculateTotalCommand { get; private set; }


        /// <summary>
        /// Constructor that instantiates a new instance of the OrderViewModel class
        /// </summary>
        public OrderLandingViewModel()
        {

            CustomersVM = new CustomerViewModel();
            ProductsVM = new ProductViewModel();
            CartVM = new CartViewModel();
            BranchVM = new BranchViewModel();
            OrdersVM = new OrderViewModel();

        }

        private void GenerateOrder()
        {

        }

    }
}
