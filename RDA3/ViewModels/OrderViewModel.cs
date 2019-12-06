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

        public OrderViewModel()
        {
            orderList = GetOrders();
            Orders = new ObservableCollection<Order>(orderList);


        }

        public List<Order> GetOrders()
        {
            var orderList = new PSWally().GetOrders();
            return orderList;
        }

        public void MakeOrder(List<Cart> cart)
        {

        }

    }
}
