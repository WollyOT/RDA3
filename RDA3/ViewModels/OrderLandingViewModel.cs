/*
* FILE          :   OrderLandingViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model handling the operations occuring on the Order
*                   page. Utilizes other view models to complete tasks.
*/
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
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private SalesRecordLandingViewModel _salesRecordVM;
        public SalesRecordLandingViewModel SalesRecordVM
        {
            get { return _salesRecordVM; }
            set { OnPropertyChanged(ref _salesRecordVM, value); }
        }

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

        public ICommand GenerateOrderCommand { get; private set; }


        /*
        * NAME      :   OrderLandingViewModel
        * PURPOSE	:   Constructor for the creation of the class. Instantiates
        *               other viewmodels to assist in Order operations.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public OrderLandingViewModel()
        {
            //other classes instantiated for Order use
            CustomersVM = new CustomerViewModel();
            ProductsVM = new ProductViewModel();
            CartVM = new CartViewModel();
            BranchVM = new BranchViewModel();
            OrdersVM = new OrderViewModel();

            //binding for button functions set
            GenerateOrderCommand = new RelayCommand(GenerateOrder);

        }

        /*
        * NAME      :   GenerateOrder
        * PURPOSE	:   Pulls info from other view models to contruct and
        *               complete an order.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   Generates a new and completed order.
        * RETURNS	:
        *   NONE
        */
        private void GenerateOrder()
        {
            OrdersVM.CurrentOrder = new Order();
            List<Cart> cartList = new List<Cart>();
            cartList = CartVM.CompleteOrder();
            OrdersVM.CurrentOrder.CustomerID = CustomersVM.SelectedCustomer.CustomerID;
            OrdersVM.CurrentOrder.BranchID = BranchVM.SelectedBranch.BranchID;

            //function called in Order view model to complete order construction
            OrdersVM.MakeOrder(cartList);
            CurrentView = SalesRecordVM;

        }

    }
}
