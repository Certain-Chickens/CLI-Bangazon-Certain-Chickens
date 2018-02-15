using System;
using System.Collections.Generic;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

/*
Original Authors: Ryan McPherson and Greg Turner
Purpose: Checks for existence of tables and creates any which are missing
*/
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
            this.AddOrderProductTable();
            this.AddPaymentTypeTable();
            this.AddProductTypeTable();
        }

        public void AddCustomerTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Customer` (
                    `CustomerId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `Name` TEXT NOT NULL,
                    `Address` TEXT NOT NULL,
                    `City` TEXT NOT NULL,
                    `State` TEXT NOT NULL,
                    `PostalCode` TEXT NOT NULL,
                    `Phone` TEXT NOT NULL);
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddCustomerTable", ex.Message);
            }
        }

        public void AddOrderzTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Orderz` (
                    `OrderId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `CustomerId` INT NOT NULL,
                    `PaymentTypeId` INT,
                    `DateCreated` varchar(80) NOT NULL);
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddOrderzTable", ex.Message);
            }
        }
        public void AddOrderProductTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `OrderProduct` (
                    `OrderProductId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `ProductId` INT NOT NULL,
                    `OrderId` INT NOT NULL,
                    FOREIGN KEY (`ProductID`) REFERENCES `Product`(`ProductID`),
                    FOREIGN KEY (`OrderID`) REFERENCES `Orderz`(`OrderID`)
                    );
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddOrderzTable", ex.Message);
            }
        }

        public void AddPaymentTypeTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `PaymentType` (
                    `PaymentTypeId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `Name` TEXT NOT NULL,
                    `AccountNumber` INT NOT NULL);
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddPaymentTypeTable", ex.Message);
            }
        }

        public void AddProductTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `Product` (
                    `ProductId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `ProductType` TEXT NOT NULL,
                    `CustomerId` INT NOT NULL,
                    `Title` TEXT NOT NULL,
                    `Description` TEXT NOT NULL,
                    `Price` DOUBLE NOT NULL,
                    `Quantity` INT NOT NULL,
                    `DateCreated` varchar(80) NOT NULL); 
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddProductTable", ex.Message);
            }
        }
        public void AddProductTypeTable()
        {
            try
            {
                _db.Update(@"CREATE TABLE IF NOT EXISTS `ProductType` (
                    `ProductTypeId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `ProductCategory` TEXT NOT NULL);
                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddProductType", ex.Message);
            }
        }
    }
}