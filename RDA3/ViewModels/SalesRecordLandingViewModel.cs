/*
* FILE          :   SalesRecordLandingViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model handling the operations occuring on the 
*                   SalesOrder page. Utilizes other view models to complete 
*                   tasks.
*/
using RDA3.Utilities;
using RDA3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace RDA3.ViewModels
{
    public class SalesRecordLandingViewModel : ObservableObject
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

        private BranchViewModel _branchVM;
        public BranchViewModel BranchVM
        {
            get { return _branchVM; }
            set { OnPropertyChanged(ref _branchVM, value); }
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

        private SalesRecordViewModel _salesRecordVM;
        public SalesRecordViewModel SalesRecordVM
        {
            get { return _salesRecordVM; }
            set { OnPropertyChanged(ref _salesRecordVM, value); }
        }

        /*
        * NAME      :   SalesRecordLandingViewModel
        * PURPOSE	:   Instantiates classes for the operation
        *               of the Sales Record view and functions.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public SalesRecordLandingViewModel()
        {
            CustomersVM = new CustomerViewModel();
            CartVM = new CartViewModel();
            ProductsVM = new ProductViewModel();
            OrdersVM = new OrderViewModel();
            BranchVM = new BranchViewModel();

            SalesRecordVM = new SalesRecordViewModel();
        }

        /*
        * NAME      :   InitializeSalesRecords
        * PURPOSE	:   For the initialization of the functions class. Pulls
        *               data from memory to construct the list of sales records.
        *               Unneccesary and will be replaced.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        private void InitializeSalesRecords()
        {
            ObservableCollection<Customer> customer = new ObservableCollection<Customer>();
            ObservableCollection<Cart> cart = new ObservableCollection<Cart>();
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            ObservableCollection<Branch> branch = new ObservableCollection<Branch>();

            customer = CustomersVM.Customers;
            cart = CartVM.Cart;
            products = ProductsVM.Products;
            orders = OrdersVM.Orders;
            branch = BranchVM.Branches;

            CompositeCollection cc = new CompositeCollection();
            cc.Add(customer);
            cc.Add(cart);
            cc.Add(products);
            cc.Add(orders);
            cc.Add(branch);
        }
    }
}
