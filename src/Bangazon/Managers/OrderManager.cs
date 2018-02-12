using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
/*
    Author: Greg Turner
    Purpose: Orderz manager methods for Orderz data manipluation
*/

namespace Bangazon.Managers
{
    public class OrderManager
    {
        // Makes a private DatabaseConnection variable named _db which will be used in the methods
        private DatabaseConnection _db;
        // set the private DatabaseConnection variable _db to equal a DatabaseConnection named db provided as an argument
        public OrderManager(DatabaseConnection db)
        {
            _db = db;
        }
        /*
        Author: Greg Turner
        Purpose: Add an Orderz entry into the database Orderz table using the details
                in the ticket provided.
        */
        public int AddNewOrderz(Orderz ticket)
        {
            int id = _db.Insert( $"insert into Orderz values (null, '{ticket.CustomerId}', '{ticket.PaymentTypeId}', '{ticket.DateCreated}')");

            return id;
        }
        /*
        Author: Greg Turner
        Purpose: Query the database for the Orderz with the same OrderId as the
                one provided.
        */
        public Orderz GetSingleOrderz(int Id)
        {
            Orderz singleOrderz = new Orderz();
            _db.Query($"SELECT * FROM Orderz WHERE Orderz.OrderId = {Id};", (SqliteDataReader reader) => {
                while (reader.Read()){
                singleOrderz.OrderId = reader.GetInt32(0);
                singleOrderz.CustomerId = reader.GetInt32(1);
                singleOrderz.PaymentTypeId = reader.GetInt32(2);
                singleOrderz.DateCreated = reader.GetDateTime(3);
                }
            });
            return singleOrderz;
        }
        /*
        Author: Greg Turner
        Purpose: Query the database for all Orderz with the same CustomerId as the
                one provided that do not have a PaymentId.
        */
        public List<Orderz> ListCompletedCustomerOrderz(int Id)
        {
            List <Orderz> completedCustomerOrders = new List <Orderz>();
            _db.Query($"SELECT * FROM `Orderz` WHERE CustomerID = {Id} AND PaymentTypeID IS NOT null", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    completedCustomerOrders.Add(new Orderz(){
                        OrderId = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        PaymentTypeId = reader[2] as int? ?? null,
                        DateCreated = reader.GetDateTime(3)
                    });
                }
            });
            return completedCustomerOrders;
        }

        // Author: Leah Duvic and Greg Turner
        // Purpose: Completing customer order by adding the payment type.

        public Orderz CompleteOrderz(int orderId, int paymentTypeId)
        {
            Orderz updatedOrder = new Orderz();
            _db.Insert($"UPDATE Orderz SET PaymentTypeId = {paymentTypeId} WHERE OrderId = {orderId}");
            updatedOrder = GetSingleOrderz(orderId);
            return updatedOrder;
        }

    }
}