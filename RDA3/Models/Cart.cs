/*
* FILE          :   Cart.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Model for the Cart object
*/
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class Cart : ObservableObject
    {
        private int productSKU;
        public int ProductSKU
        {
            get { return productSKU; }
            set { OnPropertyChanged(ref productSKU, value); }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { OnPropertyChanged(ref productName, value); }
        }

        private double productPrice;
        public double ProductPrice
        {
            get { return productPrice; }
            set { OnPropertyChanged(ref productPrice, value); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { OnPropertyChanged(ref quantity, value); }
        }

        private double linePrice;
        public double LinePrice
        {
            get { return linePrice; }
            set { OnPropertyChanged(ref linePrice, value); }
        }
    }
}
