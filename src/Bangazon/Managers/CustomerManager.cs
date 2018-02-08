using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
{
    public class CustomerManager
    {
        private List<Customer> _customerTable = new List<Customer>();
        private DatabaseConnection _db;

        public CustomerManager(DatabaseConnection db)
        {
            _db = db;
            this.AddCustomerTable();
        }

        private void AddCustomerTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Customer` (
                    `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `Name` TEXT NOT NULL,
                    `Address` TEXT NOT NULL,
                    `City` TEXT NOT NULL,
                    `State` TEXT NOT NULL,
                    `PostalCode` TEXT NOT NULL,
                    `Phone` TEXT NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("CreateCustomerTable", ex.Message);
            }
        }

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

        public Customer ActiveCustomer (int Id)
        {
            var activeCustomer = GetSingleCustomer(Id);
            return activeCustomer;
        }

    }
}