/*
* FILE          :   CustomerViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the Customer object
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

        /*
        * NAME      :   GetCustomers
        * PURPOSE	:   Calls the GetCustomers function located in
        *               the PSWally class to populate a list with
        *               contents of SQL server Branch table.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var customerList  : list of customers
        */
        public List<Customer> GetCustomers()
        {
            var customerList = new PSWally().GetCustomers();
            return customerList;
        }
    }

}
