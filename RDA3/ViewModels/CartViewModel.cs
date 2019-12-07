/*
* FILE          :   CartViewModel.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   View model for the for the cart object
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
    public class CartViewModel : ObservableObject
    {
        private Cart _selectedCartProduct;
        public Cart SelectedCartProduct
        {
            get { return _selectedCartProduct; }
            set { OnPropertyChanged(ref _selectedCartProduct, value); }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { OnPropertyChanged(ref _selectedProduct, value); }
        }

        private int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set { OnPropertyChanged(ref _quantity, value); }
        }

        private double _subtotal = 0.00;
        public double Subtotal
        {
            get { return _subtotal; }
            set { OnPropertyChanged(ref _subtotal, value); }
        }

        private double _hst = 0.00;
        public double HST
        {
            get { return _hst; }
            set { OnPropertyChanged(ref _hst, value); }
        }

        private double _total = 0.00;
        public double Total
        {
            get { return _total; }
            set { OnPropertyChanged(ref _total, value); }
        }


        public ObservableCollection<Cart> Cart { get; private set; }


        public ICommand UpdateCartCommand { get; private set; }
        public ICommand CalculateCartTotalCommand { get; private set; }

        public CartViewModel()
        {
            Cart = new ObservableCollection<Cart>();

            UpdateCartCommand = new RelayCommand(UpdateCart);
            CalculateCartTotalCommand = new RelayCommand(CalculateCartTotals);

        }

        /*
        * NAME      :   UpdateCart
        * PURPOSE	:   Pulls information from selected and set properties in
        *               Order view to create a new Cart object.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   Stores a cart object in an ObservableCollection
        * RETURNS	:
        *   NONE
        */
        private void UpdateCart()
        {
            Product product = SelectedProduct;
            Cart cart = new Cart();
            double markUp = 1.4;
            double priceBuffer = 0;

            if (product != null)
            {
                //moves values from chosen product into cart for display
                cart.ProductSKU = product.ProductSKU;
                cart.ProductName = product.ProductName;
                cart.Quantity = Quantity;
                cart.ProductPrice = (product.ProductWPrice * markUp);

                //calculates price for selected quantity of products
                priceBuffer = (product.ProductWPrice * markUp);
                Math.Round(priceBuffer, 2);
                cart.LinePrice = priceBuffer;

                Cart.Add(cart);         //new line is added to cart observable object
                Quantity = 1;
                CalculateCartTotals();   //function called to calculate the running total of the order
                OnPropertyChanged("SelectedProduct");
            }             
        }

        /*
        * NAME      :   CalculateCartTotals
        * PURPOSE	:   Calculates and updates the Subtotal, HST, and
        *               the final Total values for the current order
        *               based on the newly inserted Cart object.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   Stores data into Subtotal, HST and Total fields of Order view.
        * RETURNS	:
        *   NONE
        */
        private void CalculateCartTotals()
        {
            double hstValue = 0.13;
            double priceBuffer = 0;
            try
            {
                Cart buffer = Cart.ElementAt(Cart.Count - 1);
                priceBuffer = buffer.LinePrice;

                // Sales total values calculated and updated
                Subtotal += priceBuffer;
                Subtotal = Math.Round(Subtotal, 2); //rounded so as to prevent values from becomming unwieldy
                HST = (Subtotal * hstValue);
                HST = Math.Round(HST, 2);
                Total = Subtotal + HST;
                Total = Math.Round(Total, 2);

                OnPropertyChanged("Subtotal");
                OnPropertyChanged("HST");
                OnPropertyChanged("Total");
            }
            catch(ArgumentException e)
            {
                Console.Write("Empty Cart.");
            }
        }

        /*
        * NAME      :   ComlpeteOrder
        * PURPOSE	:   Pulls value from cart and clears it, for generating
        *               final order and preparing for next one.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<Cart> cartList : List containing the Cart object for te order
        */
        public List<Cart> CompleteOrder()
        {
            List<Cart> cartList = new List<Cart>();

            foreach (Cart row in Cart)
                cartList.Add(row);
            Cart.Clear();
            return cartList;
        }

    }
}
