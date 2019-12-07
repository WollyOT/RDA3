/*
* FILE          :   PSWally.cs
* PROJECT       :   PROG2111 - Assignment 03
* PROGRAMMER    :   Paul Smith 
* FIRST VERSION :   2019-12-07
* DESCRIPTION   :   Data layer for the accessing of the SQL database.
*/
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using RDA3.Models;
using RDA3.ViewModels;
using MySql.Data.MySqlClient;

namespace RDA3
{
    public class PSWally
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public PSWally()
        {
            
        }

        /*
        * NAME      :   GetCustomers
        * PURPOSE	:   Pulls customer info from the database to be stored
        *               in memory in the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var customers   : variable containing the customer info
        */
        public List<Customer> GetCustomers()
        {
            const string sqlStatement = @" SELECT Customer_ID, FirstName, LastName, Telephone
                                            FROM Customer                                             
                                            ORDER BY Customer_ID; ";

            using (var myConn = new MySqlConnection(connectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                var customers = DataTableToCustomerList(dataTable); //function for the insertion of data into a table

                return customers;
            }
        }

        /*
        * NAME      :   GetProducts
        * PURPOSE	:   Pulls product info from the database to be stored
        *               in memory in the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var products   : variable containing the product info
        */
        public List<Product> GetProducts()
        {
            const string sqlStatement = @" SELECT SKU, _Name, wPrice, Stock
                                            FROM Product                                             
                                            ORDER BY SKU; ";

            using (var myConn = new MySqlConnection(connectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                var products = DataTableToProductList(dataTable); //function for the insrtion of data into a table

                return products;
            }
        }

        /*
        * NAME      :   Getbranches
        * PURPOSE	:   Pulls branch info from the database to be stored
        *               in memory in the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var branches   : variable containing the branch info
        */
        public List<Branch> GetBranches()
        {
            const string sqlStatement = @" SELECT Branch_ID, BranchName
                                            FROM Branch                                             
                                            ORDER BY Branch_ID; ";

            using (var myConn = new MySqlConnection(connectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                var branches = DataTableToBranchList(dataTable); //function for the insertion of data into a table

                return branches;
            }
        }

        /*
        * NAME      :   GetOrders
        * PURPOSE	:   Pulls order info from the database to be stored
        *               in memory in the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var orders   : variable containing the order info
        */
        public List<Order> GetOrders()
        {
            const string sqlStatement = @" SELECT Order_ID, Customer_ID, Branch_ID, Order_Date, Sale_Price, Paid
                                            FROM _Order                                             
                                            ORDER BY Order_ID; ";

            using (var myConn = new MySqlConnection(connectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                var orders = DataTableToOrderList(dataTable); //function for the insertion of data into a table

                return orders;
            }
        }

        /*
        * NAME      :   GetSalesRecords
        * PURPOSE	:   Pulls sales recpord info from the database to be stored
        *               in memory in the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   var salesRecords   : variable containing the sales records info
        */
        public List<SalesRecord> GetSalesRecords()
        {
            const string sqlStatement = @" SELECT Order_ID, SKU, Quantity
                                            FROM SalesRecord                                             
                                            ORDER BY Order_ID; ";

            using (var myConn = new MySqlConnection(connectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we weill use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                var salesRecords = DataTableToSalesRecordsList(dataTable); //function for the insertion of data into a table

                return salesRecords;
            }
        }

        /*
        * NAME      :   DataTableToCustomerList
        * PURPOSE	:   Takes customer info and places it into a List object
        *               for use within the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<Customer> customers   : List containing the customer info
        */
        private List<Customer> DataTableToCustomerList(DataTable table)
        {
            var customers = new List<Customer>();
            foreach (DataRow row in table.Rows)
            {
                customers.Add(new Customer
                {
                    CustomerID = Convert.ToInt32(row["Customer_ID"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Telephone = row["Telephone"].ToString()
                });
            }
            return customers;
        }

        /*
        * NAME      :   DataTableToProductList
        * PURPOSE	:   Takes Product info and places it into a List object
        *               for use within the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<Product> products   : List containing the product info
        */
        private List<Product> DataTableToProductList(DataTable table)
        {
            var products = new List<Product>();
            foreach (DataRow row in table.Rows)
            {
                products.Add(new Product
                {
                    ProductSKU = Convert.ToInt32(row["SKU"]),
                    ProductName = row["_Name"].ToString(),
                    ProductWPrice = Convert.ToDouble(row["wPrice"]),
                    ProductStock = Convert.ToInt32(row["Stock"]),
                });
            }
            return products;
        }


        /*
        * NAME      :   DataTableToBranchList
        * PURPOSE	:   Takes branch info and places it into a List object
        *               for use within the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<Branch> branches   : List containing the branch info
        */
        private List<Branch> DataTableToBranchList(DataTable table)
        {
            var branches = new List<Branch>();
            foreach (DataRow row in table.Rows)
            {
                branches.Add(new Branch
                {
                    BranchID = Convert.ToInt32(row["Branch_ID"]),
                    BranchName = row["BranchName"].ToString()
                });
            }
            return branches;
        }


        /*
        * NAME      :   DataTableToOrderList
        * PURPOSE	:   Takes order info and places it into a List object
        *               for use within the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<Order> orders   : List containing the order info
        */
        private List<Order> DataTableToOrderList(DataTable table)
        {
            var orders = new List<Order>();
            foreach (DataRow row in table.Rows)
            {
                orders.Add(new Order
                {
                    OrderID = Convert.ToInt32(row["Order_ID"]),
                    CustomerID = Convert.ToInt32(row["Customer_ID"]),
                    BranchID = Convert.ToInt32(row["Branch_ID"]),
                    OrderDate = row["Order_Date"].ToString(),
                    Paid = Convert.ToBoolean(row["Paid"]),
                });
            }
            return orders;
        }


        /*
        * NAME      :   DataTableToSalesRecordsrList
        * PURPOSE	:   Takes sales records info and places it into a List object
        *               for use within the app.
        * INPUTS    :   
        *   NONE
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   List<SalesRecrod> salesRecords   : List containing the customer info
        */
        private List<SalesRecord> DataTableToSalesRecordsList(DataTable table)
        {
            var salesRecords = new List<SalesRecord>();
            foreach (DataRow row in table.Rows)
            {
                salesRecords.Add(new SalesRecord
                {
                    OrderID = Convert.ToInt32(row["Order_ID"]),
                    ProductSKU = Convert.ToInt32(row["SKU"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                });
            }
            return salesRecords;
        }


        /*
        * NAME      :   InsertOrder
        * PURPOSE	:   Inserts order information into database after order
        *               is succesfully completed.
        * INPUTS    :   
        *   Order order : Order to be inserted into the database
        *   int key     : key containing the location of order's current
        *                 'order line' value to be inserted
        * OUTPUTS	:
        *   NONE
        * RETURNS	:
        *   NONE
        */
        public void InsertOrder(Order order, int key)
        {
            using (var myConn = new MySqlConnection(connectionString))
            {
                const string sqlStatement = @"  CALL GenerateOrder (@OrderID, @CustomerID, @BranchID, @OrderDate, @SKU, @ProductQuantity, @PaidStatus); ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@OrderID", order.OrderID);
                myCommand.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                myCommand.Parameters.AddWithValue("@BranchID", order.BranchID);
                myCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                myCommand.Parameters.AddWithValue("@SKU", order.CartContents[key].ProductSKU);
                myCommand.Parameters.AddWithValue("@ProductQuantity", order.CartContents[key].Quantity);
                myCommand.Parameters.AddWithValue("@PaidStatus", order.Paid);

                myConn.Open();              //connection opened and data inserted via command string
                myCommand.ExecuteNonQuery();
            }

        }
    }
}
