/*
* FILE          :   Order.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Model for the Order object
*/
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class Order : ObservableObject
    {
        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { OnPropertyChanged(ref orderID, value); }
        }

        private int customerID;
        public int CustomerID
        {
            get { return customerID; }
            set { OnPropertyChanged(ref customerID, value); }
        }

        private int branchID;
        public int BranchID
        {
            get { return branchID; }
            set { OnPropertyChanged(ref branchID, value); }
        }

        private string orderDate;
        public string OrderDate
        {
            get { return orderDate; }
            set { OnPropertyChanged(ref orderDate, value); }
        }

        private double salePrice;
        public double SalePrice
        {
            get { return salePrice; }
            set { OnPropertyChanged(ref salePrice, value); }
        }

        private bool paid;
        public bool Paid
        {
            get { return paid; }
            set { OnPropertyChanged(ref paid, value); }
        }

        private Dictionary<int, Cart> cartContents;
        public Dictionary<int, Cart> CartContents
        {
            get { return cartContents; }
            set { OnPropertyChanged(ref cartContents, value); }
        }
    }
}
