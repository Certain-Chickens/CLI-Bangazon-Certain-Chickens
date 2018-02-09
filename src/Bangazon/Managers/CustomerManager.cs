using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
{
    public class CustomerManager
    {
        private DatabaseConnection _db;
        public static Customer currentCustomer;

        // Method to establish a connection with the database, database conenction is passed in as an argument
        public CustomerManager(DatabaseConnection db)
        {
            _db = db;
        }

        private List<Customer> _customerTable = new List<Customer>();

        public int AddNewCustomer(Customer person)
        {
            // _customerTable.Add(person);
             int id = _db.Insert( $"insert into Customer values (null, '{person.Name}', '{person.Address}', '{person.City}', '{person.State}', '{person.PostalCode}', '{person.Phone}')");

            return id;  
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