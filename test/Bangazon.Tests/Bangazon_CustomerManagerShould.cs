using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers.Tests
{
    public class CustomerManagerShould
    {
        private Customer _person1;
        private Customer _person2;

        private List<Customer> _allCustomers;
        private  CustomerManager _cm;
        private DatabaseConnection _db;

        public CustomerManagerShould()
        {
            //Find path to database
            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
            DatabaseConnection db = new DatabaseConnection(prodPath);
            _db = db;
            _cm = new CustomerManager(_db);

            // Ensure there is a database with tables at the end of the test database connection
            DatabaseStartup databaseStartup = new DatabaseStartup(_db);
        }

        [Fact]
        public void AddNewCustomer()
        {
            Customer person1 = new Customer();
                person1.Name = "Brian";
                person1.Address = "5050 Itunes Ln";
                person1.City= "Nashville";
                person1.State= "Georgia";
                person1.PostalCode= "44145";
                person1.Phone="440-111-4444";
            var result = _cm.AddNewCustomer(person1);

            Assert.True(result != 0);
        }

        [Fact]
        public void GetSingleCustomer()
        {
            var result = _cm.GetSingleCustomer(1);
            Assert.Equal(result.Id, 1);

        }

        [Fact]
        public void ListCustomers()
        {
            Customer _person2 = new Customer();
                _person2.Name = "Johnny";
                _person2.Address = "7877 Happy Drive";
                _person2.City= "San Fransisco";
                _person2.State= "California";
                _person2.PostalCode= "90210";
                _person2.Phone="736-111-4433";

            Customer _person3 = new Customer();
                _person3.Id = 1;
                _person3.Name = "Johnny";
                _person3.Address = "7877 Happy Drive";
                _person3.City= "San Fransisco";
                _person3.State= "California";
                _person3.PostalCode= "90210";
                _person3.Phone="736-111-4433";

            _cm.AddNewCustomer(_person2);
            List<Customer> customerList = _cm.ListCustomers();

            List<Customer> _allCustomers = new List<Customer>();
            _allCustomers.Add(_person3);

            Assert.Equal(_allCustomers[0].Id, customerList[0].Id);

        }

        // // Author: Leah Duvic
        // // Purpose: setting the customer to active customer once selected.

        [Fact]
        public void ActiveCustomer()
        {
            Customer _person4 = new Customer();
                _person4.Name = "Hank";
                _person4.Address = "74 Unit way";
                _person4.City= "Fresno";
                _person4.State= "California";
                _person4.PostalCode= "0987";
                _person4.Phone="736-111-4433";
            _cm.AddNewCustomer(_person4);

            var activeCustomer = _cm.ActiveCustomer(3);

            Assert.Equal(activeCustomer.Name, "Hank");
        }
    }
}
