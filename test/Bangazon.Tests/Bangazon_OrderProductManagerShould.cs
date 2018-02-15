using System;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

/*  
    Author: Greg Turner
    Purpose: Testing OrderProduct manager methods
*/

namespace Bangazon.Tests

{
    public class OrderProductManagerShould : IDisposable
    {
        private DatabaseConnection _db;
        private OrderProductManager _orderProductManager;
        private OrderManager _orderManager;
        private ProductManager _productManager;
        private OrderProduct _orderProduct;
        private Orderz _orderz;
        private Product _product;
        private Product _product2;

        /*  Method to clear the OrderProduct table from the Test database. This will be 
            called by Dispose method. */
        public void Dispose()
        {
            // Clear any data for the Orderz, Product, and OrderProduct tables in the test database
            _db.Update($"DELETE FROM OrderProduct;");
            _db.Update($"DELETE FROM Orderz;");
            _db.Update($"DELETE FROM Product;");
            // Reset the Id sequence so new entries begin with 1
            _db.Update($"DELETE FROM sqlite_sequence WHERE name='OrderProduct';");
            _db.Update($"DELETE FROM sqlite_sequence WHERE name='Orderz';");
            _db.Update($"DELETE FROM sqlite_sequence WHERE name='Product';");
        }
        public OrderProductManagerShould()
        {
            // Set string variable prodPath to contain the path to the test database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            // Create connection to test database and capture in DatabaseConnection variable db
            DatabaseConnection db = new DatabaseConnection(prodPath);
            // Set the private DatabaseConnection variable of _db to equal the DatabaseConnection of db
            _db = db;
            // Ensure there is a database with tables at the end of the test database connection
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);

            /*  Set the private OrderProduct variable _OrderProduct to be a new instance of 
                OrderProduct connected to the test database */


            _orderProductManager = new OrderProductManager(_db);
            _orderManager = new OrderManager(_db);
            _productManager = new ProductManager(_db);

            // Create a new Orderz called _orderz for test and set the properties
            _orderz = new Orderz();
                _orderz.CustomerId = 1;
                _orderz.PaymentTypeId = 1;
                _orderz.DateCreated= DateTime.Now;

            // Create a new Product called _product for test and set the properties
            _product = new Product();
                _product.ProductType = "transpotation";
                _product.CustomerId = 1;
                _product.Title = "Bike";
                _product.Description = "Blue Bike";
                _product.Price = 2.00;
                _product.Quantity = 2;
                _product.DateCreated = DateTime.Now;

            _product2 = new Product();
                _product2.ProductType = "transportation";
                _product2.CustomerId = 1;
                _product2.Title = "Horse";
                _product2.Description = "Blue Horse";
                _product2.Price = 3.00;
                _product2.Quantity = 4;
                _product2.DateCreated = DateTime.Now;

        }
        [Fact]
        public void AddProductToOrder()
        {
            int newOrderzId = _orderManager.AddNewOrderz(_orderz);
            int newProductId = _productManager.Add(_product);

            int result = _orderProductManager.AddProductToOrder(newProductId, newOrderzId);
            Assert.True(result != 0);
        }

        [Fact]
        public void ListProductsOnOrder()
        {
            int newOrderzId = _orderManager.AddNewOrderz(_orderz);
            int newProductId = _productManager.Add(_product2);
            int newProductId2 = _productManager.Add(_product2);

            int result1 = _orderProductManager.AddProductToOrder(newProductId, newOrderzId);
            int result2 = _orderProductManager.AddProductToOrder(newProductId2, newOrderzId);
            Product sample = new Product();

            List<Product> productList = _orderProductManager.ListProductsOnOrder(newOrderzId);
            foreach (Product p in productList){
                if (p.ProductId == newProductId2) {
                    sample = p;
                }
            }
            
            Assert.Equal(_product2.Title, sample.Title);
        }
    }
}

