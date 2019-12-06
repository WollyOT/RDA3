using RDA3.Models;
using RDA3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RDA3.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { OnPropertyChanged(ref _selectedProduct, value); }
        }

        public ObservableCollection<Product> Products { get; private set; }
        public List<Product> productList { get; set; }



        public ProductViewModel()
        {
            productList = GetProducts();

            Products = new ObservableCollection<Product>(productList);


        }

        public void LoadGetProducts()
        {
            Products = new ObservableCollection<Product>();

        }

        public List<Product> GetProducts()
        {
            var productList = new PSWally().GetProducts();
            return productList;
        }
    }
}
