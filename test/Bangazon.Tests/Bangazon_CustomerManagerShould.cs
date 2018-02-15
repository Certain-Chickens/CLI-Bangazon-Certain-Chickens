using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.Win32.SafeHandles;
/*
Original Authors: Ryan McPherson and Kevin Haggerty
Updated By: Greg Turner
Purpose: Testing CustomerManager methods
*/
namespace Bangazon.Managers.Tests
{
    public class CustomerManagerShould : IDisposable
    {
        private Customer _person1;
        private Customer _person2;
        private Customer _person3;
        private Customer _person4;

        private List<Customer> _allCustomers;
        private  CustomerManager _cm;
        private DatabaseConnection _db;
        /*  Method to clear the Customer table from the Test database. This will be 
            called by Dispose method. */
        public void Dispose()
        {
            // Clear any data Customer table in the test database
            _db.Update($"DELETE FROM Customer;");
            // Reset the Id sequence so new entries begin with 1
            _db.Update($"DELETE FROM sqlite_sequence WHERE name='Customer';");
        }
        public CustomerManagerShould()
        {
            //Find path to database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            DatabaseConnection db = new DatabaseConnection(prodPath);
            _db = db;
            _cm = new CustomerManager(_db);

            // Ensure there is a database with tables at the end of the test database connection
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);


             _person1 = new Customer();
                _person1.Name = "Brian";
                _person1.Address = "5050 Itunes Ln";
                _person1.City= "Nashville";
                _person1.State= "Georgia";
                _person1.PostalCode= "44145";
                _person1.Phone="440-111-4444";

            _person2 = new Customer();
                _person2.Name = "Johnny";
                _person2.Address = "7877 Happy Drive";
                _person2.City= "San Fransisco";
                _person2.State= "California";
                _person2.PostalCode= "90210";
                _person2.Phone="736-111-4433";

            _person3 = new Customer();
                _person3.Id = 1;
                _person3.Name = "Johnny";
                _person3.Address = "7877 Happy Drive";
                _person3.City= "San Fransisco";
                _person3.State= "California";
                _person3.PostalCode= "90210";
                _person3.Phone="736-111-4433";

            _person4 = new Customer();
                _person4.Name = "Hank";
                _person4.Address = "74 Unit way";
                _person4.City= "Fresno";
                _person4.State= "California";
                _person4.PostalCode= "0987";
                _person4.Phone="736-111-4433";
        }

        [Fact]
        public void AddNewCustomer()
        {

            int result = _cm.AddNewCustomer(_person1);

            Assert.True(result != 0);
        }

        [Fact]
        public void GetSingleCustomer()
        {

            int newCustomer =  _cm.AddNewCustomer(_person1);
            Customer result = _cm.GetSingleCustomer(newCustomer);

            Assert.Equal(newCustomer, result.Id);

        }

        [Fact]
        public void ListCustomers()
        {
            _cm.AddNewCustomer(_person1);
            _cm.AddNewCustomer(_person2);
            int testId = _cm.AddNewCustomer(_person3);
            Customer testCustomer = _cm.GetSingleCustomer(testId);

            Customer lastCustomerFromList = new Customer();
            List<Customer> customerList = _cm.ListCustomers();
            foreach (Customer c in customerList){
                if (c.Id == testId){
                    lastCustomerFromList = c;
                }
            }

            Assert.Equal(testCustomer.Id, lastCustomerFromList.Id);
        }

        // // Author: Leah Duvic
        // // Purpose: setting the customer to active customer once selected.

        [Fact]
        public void ActiveCustomer()
        {
            int testId = _cm.AddNewCustomer(_person4);

            Customer singleCustomer = _cm.GetSingleCustomer(testId);
            Customer activeCustomer = _cm.ActiveCustomer(testId);

            Assert.Equal(singleCustomer.Id, activeCustomer.Id);
        }
    }
}
