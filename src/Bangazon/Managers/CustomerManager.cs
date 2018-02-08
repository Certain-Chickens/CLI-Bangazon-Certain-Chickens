using System;
using System.Collections.Generic;
using System.Linq;

namespace Bangazon
{
    public class CustomerManager
    {
        private List<Customer> _customerTable = new List<Customer>();

        public void Add(Customer person)
        {
            _customerTable.Add(person);
        }
        public Customer GetSingleCustomer (int Id)
        {
            return _customerTable.Where(c => c.Id == Id).Single();
        }

        public List<Customer> ListCustomers ()
        {
            return _customerTable;
        }

        // Author: Leah Duvic
        // Purpose: setting the customer to active customer once selected.
        
        public Customer ActiveCustomer (int Id)
        {   
            var activeCustomer = GetSingleCustomer(Id);
            return activeCustomer;
        }

    }
}