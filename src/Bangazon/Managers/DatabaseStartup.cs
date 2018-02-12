using System;
using System.Collections.Generic;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class DatabaseStartup
    {

        private DatabaseConnection _db;

        public DatabaseStartup(DatabaseConnection db)
        {
            _db = db;
            this.AddCustomerTable();
            this.AddOrderzTable();
            this.AddProductTable();
            this.AddPaymentTypeTable();
            this.AddProductTypeTable();
        }

        public void AddCustomerTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Customer` (
                    `CustomerId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `Name` TEXT NOT NULL,
                    `Address` TEXT NOT NULL,
                    `City` TEXT NOT NULL,
                    `State` TEXT NOT NULL,
                    `PostalCode` TEXT NOT NULL,
                    `Phone` TEXT NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("AddCustomerTable", ex.Message);
            }
        }

        public void AddOrderzTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Orderz` (
                    `OrderId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `CustomerId` INT NOT NULL,
                    `PaymentTypeId` INT,
                    `DateCreated` varchar(80) NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("AddOrderzTable", ex.Message);
            }
        }


        public void AddPaymentTypeTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `PaymentType` (
                    `PaymentTypeId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `Name` TEXT NOT NULL,
                    `AccountNumber` TEXT NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("AddPaymentTypeTable", ex.Message);
            }
        }
        public void AddProductTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Product` (
                    `ProductId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `ProductTypeId` INT NOT NULL,
                    `CustomerId` INT NOT NULL,
                    `Title` TEXT NOT NULL,
                    `Description` TEXT NOT NULL,
                    `Price` DOUBLE NOT NULL,
                    `Quanitity` INT NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("AddProductTable", ex.Message);
            }
        }
        public void AddProductTypeTable() {
            try {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `ProductType` (
                    `ProductTypeId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `ProductCategory` TEXT NOT NULL);
                ");
            } catch (Exception ex) {
                Console.WriteLine("AddProductType", ex.Message);
            }
        }

    }

}