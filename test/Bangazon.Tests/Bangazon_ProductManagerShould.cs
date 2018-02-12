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
        public void Dispose()
        {
            // Clear any data Product table in the test database
            _db.Update($"DELETE FROM Product;");
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
            //  Assert that the returned OrderId captured within return will not be 0
            Assert.True(result != 0);
        }


        // [Fact]
        // public void ListAllProducts()
        // {
        //     ProductManager productmanager = new ProductManager();
        //     productmanager.Add(_product);
        //     List<Product> listproduct = productmanager.ListProducts();
        //     Assert.Contains(_product, listproduct);
        // }

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
            _productManager.Add(_product);
            var result = _productManager.GetSingleProduct(1);
            //  Assert that the returned DateCreated captured within return will not be 0
            Assert.Equal(1, result.CustomerId);
        }

        // [Fact]
        // public void UpdateProduct()
        // {

        //     // Pass in Properties


        //     ProductManager productmanager = new ProductManager();
        //     productmanager.Add(_product);
        //     // productmanager.UpdateSingleProduct(_product);
        //     Product singleProduct = productmanager.GetSingleProduct(1);

        //     Assert.Equal(singleProduct.Title, "Motorcycle");
        // }
    }

}