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

        private int productSKU;
        public int ProductSKU
        {
            get { return productSKU; }
            set { OnPropertyChanged(ref productSKU, value); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { OnPropertyChanged(ref quantity, value); }
        }

    }
}
