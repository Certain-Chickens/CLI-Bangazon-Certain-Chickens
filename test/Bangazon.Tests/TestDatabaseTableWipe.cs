using System;
using System.Collections.Generic;
using Xunit;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon.Tests
{
    public class TestDatabaseTableWipe
    {
        private DatabaseConnection _testDb;
        public void TestDatabaseSetup()
        {
        // Set string variable prodPath to contain the path to the test database
        string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_TEST_DB");
        // Create connection to test database and capture in DatabaseConnection variable db
        DatabaseConnection db = new DatabaseConnection(prodPath);
        // Set the private DatabaseConnection variable of _db to equal the DatabaseConnection of db
        _testDb = db;
        // Ensure there is a database with tables at the end of the test database connection
        DatabaseStartup databaseStartup = new DatabaseStartup(_testDb);
        }

        public void OrderzTableWipe()
        {

            // Clear any data Orderz table in the test database then drop it for pristine testing
            _testDb.Update($"DELETE FROM Orderz;");
            _testDb.Update($"DROP TABLE IF EXISTS Orderz;");
            // Add new Orderz table to test database
            _testDb.Update(@"CREATE TABLE IF NOT EXISTS `Orderz` (
                    `OrderId` INTEGER PRIMARY KEY AUTOINCREMENT,
                    `CustomerId` INT NOT NULL,
                    `PaymentTypeId` INT,
                    `DateCreated` varchar(80) NOT NULL);
                ");
        }
    }
}