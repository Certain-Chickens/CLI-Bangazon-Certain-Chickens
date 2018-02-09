using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers.Tests
{
    public class CustomerManagerShould
    {
        private Customer _customer;
        private  CustomerManager _cm;
        private DatabaseConnection _db;


        public CustomerManagerShould()
        {
            //Find path to database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            DatabaseConnection db = new DatabaseConnection(prodPath);
            _db = db;
            _cm = new CustomerManager(_db);
            // properties of customer for hard coding.

            // _customer = new Customer(
            //     1,
            //     "Sam Phillips",
            //     "1 Main St",
            //     "Nashville",
            //     "TN",
            //     "37221",
            //     "6157865437"
            // );


        }
        [Fact]
        public void AddNewCustomer()
        {
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);
            Customer person = new Customer();

                person.Name = "NOOO NO";
                person.Address = "5050 Itunes Ln";
                person.City= "Nashville";
                person.State= "Georgia";
                person.PostalCode= "44145";
                person.Phone="440-111-4444";

            var result = _cm.AddNewCustomer(person);

            Assert.True(result != 0);
        }

        [Fact]
        public void GetSingleCustomer()
        {
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);
            Customer person = new Customer();

            var result = _cm.GetSingleCustomer(1);

            Assert.Equal(result, 1);
        }

        // [Fact]
        // public void ListCustomers()
        // {
        //     CustomerManager manager = new CustomerManager();
        //     manager.Add(_customer);
        //     List<Customer> allCustomers = manager.ListCustomers();

        //     Assert.Contains(_customer, allCustomers);
        // }

        // // Author: Leah Duvic
        // // Purpose: setting the customer to active customer once selected.

        // [Fact]
        // public void ActiveCustomer()
        // {
        //     CustomerManager manager = new CustomerManager();
        //     manager.Add(_customer);
        //     var activeCustomer = manager.ActiveCustomer(1);

        //     Assert.Equal(activeCustomer.Id, 1);
        // }
    }
}
