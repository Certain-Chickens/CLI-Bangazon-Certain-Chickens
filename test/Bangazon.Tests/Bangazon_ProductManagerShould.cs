using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;
using Microsoft.Win32.SafeHandles;

namespace Bangazon.Managers.Tests
{

    public class ProductManagerShould : IDisposable
    {
        private Product _product;
        private Product _product2;
        // Private DatabaseConnection variable _db to be used in the tests;
        private ProductManager _productManager;
        private DatabaseConnection _db;
        /*  Method to clear the Product table from the Test database. This will be 
            called by Dispose method. */
        public void Dispose()
        {
            // Clear any data Product table in the test database
            _db.Update($"DELETE FROM Product;");
            // Reset the Id sequence so new entries begin with 1
            _db.Update($"DELETE FROM sqlite_sequence WHERE name='Product';");
        }

        public ProductManagerShould()
        {
            // Set string variable prodPath to contain the path to the test database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            // Create connection to test database and capture in DatabaseConnection variable db
            DatabaseConnection db = new DatabaseConnection(prodPath);
            // Set the private DatabaseConnection variable of _db to equal the DatabaseConnection of db
            _db = db;
            // Ensure there is a database with tables at the end of the test database connection
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);

            _productManager = new ProductManager(_db);
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
        public void AddProduct()
        {
            /*  Send the new _product to the AddNewOrderz method and capture the return 
                in the variable named result */
            var result = _productManager.Add(_product);
            //  Assert that the returned ProductId captured within return will not be 0
            Assert.True(result != 0);
        }


        [Fact]
        public void ListAllProducts()
        {
            int item1 = _productManager.Add(_product);
            Product item1Full = _productManager.GetSingleProduct(item1);
            Product sample = new Product();

            List<Product> productList = _productManager.ListProducts();
            foreach (Product p in productList){
                if (p.ProductId == item1) {
                    sample = p;
                }
            }
            
            Assert.Equal(item1Full.ProductId, sample.ProductId);
        }

        // [Fact]
        // public void RemoveProduct()
        // {
        //     ProductManager productmanager = new ProductManager();
        //     productmanager.Add(_product);

        //     Product removedProduct = productmanager.RemoveSingleProduct(1);

        //     List<Product> updatedList = productmanager.ListProducts();

        //     Assert.DoesNotContain(removedProduct, updatedList);
        // }

        [Fact]
        public void GetSingleProduct()
        {
            /*  Send the new _orderz to the AddNewOrderz method and capture the return 
                in the variable named result */
            var testerId = _productManager.Add(_product);
            var result = _productManager.GetSingleProduct(testerId);
            //  Assert that the returned DateCreated captured within return will not be 0
            Assert.Equal(testerId, result.ProductId);
        }

        // [Fact]
        // public void UpdateProduct()
        // {
        //     // Pass in Properties
        //     var editedProduct = _productManager.Update;
        //     productManager.Add(_product);
        //     // productmanager.UpdateSingleProduct(_product);
        //     Product singleProduct = productManager.GetSingleProduct(1);

        //     Assert.Equal(singleProduct.Title, "Motorcycle");
        // }
    }

}