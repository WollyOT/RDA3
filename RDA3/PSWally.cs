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

                var customers = DataTableToCustomerList(dataTable);

                return customers;
            }
        }

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

                var products = DataTableToProductList(dataTable);

                return products;
            }
        }

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

                var branches = DataTableToBranchList(dataTable);

                return branches;
            }
        }

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

                var orders = DataTableToOrderList(dataTable);

                return orders;
            }
        }

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

                var orders = DataTableToSalesRecordsList(dataTable);

                return orders;
            }
        }

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
                    SalePrice = Convert.ToDouble(row["Sale_Price"]),
                    Paid = Convert.ToBoolean(row["Paid"]),
                });
            }
            return orders;
        }

        private List<SalesRecord> DataTableToSalesRecordsList(DataTable table)
        {
            var salesRecord = new List<SalesRecord>();

            foreach (DataRow row in table.Rows)
            {
                salesRecord.Add(new SalesRecord
                {
                    OrderID = Convert.ToInt32(row["Order_ID"]),
                    ProductSKU = Convert.ToInt32(row["SKU"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                });
            }
            return salesRecord;
        }

    }
}
