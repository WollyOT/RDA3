/*
* FILE          :   OrderViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the Order object
*/
using RDA3.Models;
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set { OnPropertyChanged(ref _selectedOrder, value); }
        }

        private Order _currentOrder;
        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set { OnPropertyChanged(ref _currentOrder, value); }
        }

        public ObservableCollection<Order> Orders { get; private set; }
        public List<Order> orderList { get; set; }

        /*
        * NAME      :   OrderViewModel
        * PURPOSE	:   Constructor for the OrderViewModel class. Instantiates
        *               variables needed for the maintainence of Orders.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public OrderViewModel()
        {
            orderList = GetOrders();
            Orders = new ObservableCollection<Order>(orderList);
            CurrentOrder = new Order();

        }

        /*
        * NAME      :   GetOrders
        * PURPOSE	:   Calls the GetOrders function located in
        *               the PSWally class to populate a list with
        *               contents of SQL server Order table.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var orderList  : list of orders
        */
        public List<Order> GetOrders()
        {
            var orderList = new PSWally().GetOrders();
            return orderList;
        }

        /*
        * NAME      :   MakeOrder
        * PURPOSE	:   Completes construction of order that was started 
        *               in OrderLandingViewModel. Pulls value from properties
        *               and constructs finished Order object.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   Completed order.
        * RETURNS	:
        *   NONE
        */
        public void MakeOrder(List<Cart> cart)
        {
            PSWally connection = new PSWally();
            Order buffer = Orders.ElementAt(Orders.Count - 1);
            int oID = buffer.OrderID;            
            int key = 0;

            // values stored in temporary Order object
            CurrentOrder.CartContents = new Dictionary<int, Cart>();
            CurrentOrder.OrderID = oID + 1;
            CurrentOrder.OrderDate = DateTime.Today.ToShortDateString();
            CurrentOrder.Paid = true;

            // iterates through cart contents for each completed line
            foreach (Cart row in cart)
                CurrentOrder.CartContents.Add(row.ProductSKU, row);

            // iterates through line total values and calculates total price
            foreach (Cart row in CurrentOrder.CartContents.Values)
            {
                CurrentOrder.SalePrice += row.LinePrice;
                key = row.ProductSKU;
                connection.InsertOrder(CurrentOrder, key); //stores Order in database

            }
            // adds object to observable collection of Orders
            Orders.Add(CurrentOrder);
        }
    }
}
