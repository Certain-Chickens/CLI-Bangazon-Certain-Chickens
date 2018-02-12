using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;
using Microsoft.Win32.SafeHandles;
/*
Author: Greg Turner
Purpose: Testing Orderz manager methods
*/

namespace Bangazon.Managers.Tests

{
    public class OrderManagerShould : IDisposable
    {
        // Private Orderz variables _orderz, _orderz2 and _orders3 to be used in the tests
        private Orderz _orderz;
        private Orderz _orderz2;
        private Orderz _orderz3;
        // Private List of Orderz variables _allOrderz and _allCustomer1Orderz to be used in test
        private List<Orderz> _allOrderz;
        private List<Orderz> _allCustomer1Orderz;

        // Private OrderManager variable _orderManager to be used in the tests
        private OrderManager _orderManager;
        // Private DatabaseConnection variable _db to be used in the tests;
        private DatabaseConnection _db;
        /*  Method to clear the Orderz table from the Test database that will be 
            called by Dispose method */
        public void Dispose()
        {
            // Clear any data Orderz table in the test database
            _db.Update($"DELETE FROM Orderz;");
            _db.Update($"DROP TABLE IF EXISTS Orderz;");
            // Add new Orderz table to test database
            _db.Update(@"CREATE TABLE IF NOT EXISTS `Orderz` (
                    `OrderId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `CustomerId` INT NOT NULL,
                    `PaymentTypeId` INT,
                    `DateCreated` varchar(80) NOT NULL);
                    ");
        }

        public OrderManagerShould()
        {
            // Set string variable prodPath to contain the path to the test database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            // Create connection to test database and capture in DatabaseConnection variable db
            DatabaseConnection db = new DatabaseConnection(prodPath);
            // Set the private DatabaseConnection variable of _db to equal the DatabaseConnection of db
            _db = db;
            // Ensure there is a database with tables at the end of the test database connection
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);

            /*  Set the private OrderManager variable _orderManager to be a new instance of 
                OrderManager connected to the test database */


            _orderManager = new OrderManager(_db);
            // Create a new Orderz called ticket for test and set the properties
            _orderz = new Orderz();
                _orderz.CustomerId = 1;
                _orderz.PaymentTypeId = 1;
                _orderz.DateCreated= DateTime.Now;
            // Create a new Orderz for CustomerId 1 with no PaymentTypeId
            _orderz2 = new Orderz();
            _orderz2.CustomerId = 1;
            _orderz2.PaymentTypeId = null;
            _orderz2.DateCreated= DateTime.Now;
            // Create a new Orderz for CustomerId 2 with a PaymentTypeId
            _orderz3 = new Orderz();
            _orderz3.CustomerId = 2;
            _orderz3.PaymentTypeId = 1;
            _orderz3.DateCreated= DateTime.Now;
        }
        [Fact]
        /*
        Author: Greg Turner
        Purpose: Test for adding a new Orderz to the Orderz table of the test database
        */
        public void AddNewOrderz()
        { 
            /*  Send the new _orderz to the AddNewOrderz method and capture the return 
                in the variable named result */
            var result = _orderManager.AddNewOrderz(_orderz);
            //  Assert that the returned OrderId captured within return will not be 0
            Assert.True(result != 0);
        }
        /*
        Author: Greg Turner
        Purpose: Test returning a single Orderz from the Orderz table in the test database
                requested by OrderId.
        */
        [Fact]
        public void GetSingleOrderz()
        {
            /*  Send the new _orderz to the AddNewOrderz method and capture the return 
                in the variable named result */
            _orderManager.AddNewOrderz(_orderz);
            var result = _orderManager.GetSingleOrderz(1);
            //  Assert that the returned DateCreated captured within return will not be 0
            Assert.Equal(1, result.CustomerId);
        }

        /*
        Author: Greg Turner
        Purpose: Test returning a list of Orderz from the Orderz table in the test database
                for a requested CustomerId that have a PaymentTypeId.
        */
        [Fact]
        public void ListCompletedCustomerOrderz()
        {
            //  Call AddNewOrderz method to add the 3 new Orderz to the Orderz table
            _orderManager.AddNewOrderz(_orderz);
            _orderManager.AddNewOrderz(_orderz2);
            _orderManager.AddNewOrderz(_orderz3);
            // Capture all 3 Orderz in a list called _allOrderz
            _allOrderz = new List<Orderz>();
            _allOrderz.Add(_orderz);
            _allOrderz.Add(_orderz2);
            _allOrderz.Add(_orderz3);
            /*  Capture both the completed and incomplete Orderz for CustomerId 1 
                in a list called _allCustomer1Orderz */
            _allCustomer1Orderz = new List<Orderz>();
            _allCustomer1Orderz.Add(_orderz);
            _allCustomer1Orderz.Add(_orderz2);
            
            /* Capture the returned list from the ListCompletedCustomerOrderz in 
                a list called revenue */
            List<Orderz> revenue = _orderManager.ListCompletedCustomerOrderz(1);
            /*  Test to make sure revenue does not contain CustomerId 2 nor CustomerId 1's
                incomplete Orderz */
            Assert.NotEqual(_allOrderz, revenue);
            Assert.NotEqual(_allCustomer1Orderz, revenue);
        }

        /*
        Author: Leah Duvic and Greg Turner
        Purpose: Testing completing an Orderz in the Orderz table of the test database specified by
                OrderId by adding the specified PaymentTypeId.
        */
        [Fact]
        public void CompleteOrderz()
        {
            // Add the new Orderz to the Orderz table in the test database
            _orderManager.AddNewOrderz(_orderz2);
            // Capture the returned updated Orderz in the variable result
            var result = _orderManager.CompleteOrderz(1, 1);
            // Test the PaymentTypeId in the Orderz is now 1
            Assert.Equal(1, result.PaymentTypeId);
        }
    }
}

