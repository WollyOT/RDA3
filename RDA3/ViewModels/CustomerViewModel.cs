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
    public class CustomerViewModel : ObservableObject
    {
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { OnPropertyChanged(ref _selectedCustomer, value); }
        }

        public ObservableCollection<Customer> Customers { get; private set; }
        public List<Customer> customerList { get; set; }
               
        public CustomerViewModel()
        {
            customerList = GetCustomers();
            Customers = new ObservableCollection<Customer>(customerList);

        }
        
        public List<Customer> GetCustomers()
        {
            var customerList = new PSWally().GetCustomers();
            return customerList;
        }
    }

}
