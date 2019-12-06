using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDA3.Models
{
    public class Product : ObservableObject
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

        private double productWPrice;
        public double ProductWPrice
        {
            get { return productWPrice; }
            set { OnPropertyChanged(ref productWPrice, value); }
        }

        private int productStock;
        public int ProductStock
        {
            get { return productStock; }
            set { OnPropertyChanged(ref productStock, value); }
        }
    }
}
