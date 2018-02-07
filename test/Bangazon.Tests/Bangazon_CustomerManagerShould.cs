using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class CustomerManagerShould
    {
        private Customer _customer;

        public CustomerManagerShould()
        {
            // properties of customer for hard coding.

            _customer = new Customer(
                1,
                "Sam Phillips",
                "1 Main St",
                "Nashville",
                "TN",
                "37221",
                "6157865437"
            );
        }
        [Fact]
        public void AddNewCustomer()
        {
            Assert.Equal(_customer.Id, 1);
        }

        [Fact]
        public void GetSingleCustomer()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);
            Customer customer = manager.GetSingleCustomer(1);

            Assert.Equal(customer.Id, 1);
        }

        [Fact]
        public void ListCustomers()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);
            List<Customer> allCustomers = manager.ListCustomers();

            Assert.Contains(_customer, allCustomers);
        }
        
    }
}
