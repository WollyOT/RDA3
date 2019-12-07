/*
* FILE          :   SalesRecord.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Model for the SalesRecord object
*/
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class SalesRecord : ObservableObject
    {
        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { OnPropertyChanged(ref orderID, value); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { OnPropertyChanged(ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { OnPropertyChanged(ref lastName, value); }
        }

        private int productSKU;
        public int ProductSKU
        {
            get { return productSKU; }
            set { OnPropertyChanged(ref productSKU, value); }
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

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { OnPropertyChanged(ref quantity, value); }
        }

        private Dictionary<int, Cart> cartContents;
        public Dictionary<int, Cart> CartContents
        {
            get { return cartContents; }
            set { OnPropertyChanged(ref cartContents, value); }
        }
    }
}
