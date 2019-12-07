/*
* FILE          :   Customer.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Model for the Customer object
*/
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class Customer : ObservableObject
    {
        private int customerID;
        public int CustomerID
        {
            get { return customerID; }
            set { OnPropertyChanged(ref customerID, value); }
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

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { OnPropertyChanged(ref telephone, value); }
        }
    }
}
