/*
* FILE          :   BranchViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the Product object
*/
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

        /*
        * NAME      :   ProductViewModel
        * PURPOSE	:   Constructor for the class. Populates collection
        *               with Product values.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public ProductViewModel()
        {
            productList = GetProducts();
            Products = new ObservableCollection<Product>(productList);
        }

        /*
        * NAME      :   GetProducts
        * PURPOSE	:   Calls the GetProducts function located in
        *               the PSWally class to populate a list with
        *               contents of SQL server Products table.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var productList  : list of products
        */
        public List<Product> GetProducts()
        {
            var productList = new PSWally().GetProducts();
            return productList;
        }
    }
}
