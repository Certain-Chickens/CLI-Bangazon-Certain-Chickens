using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
/*
Author: Greg Turner
Purpose: OrderProduct manager methods for OrderProduct data manipluation
*/

namespace Bangazon.Managers
{
    public class OrderProductManager
    {
        // Makes a private DatabaseConnection variable named _db which will be used in the methods
        private DatabaseConnection _db;
        // set the private DatabaseConnection variable _db to equal a DatabaseConnection named db provided as an argument
        public OrderProductManager(DatabaseConnection db)
        {
            _db = db;
        }
        private List<OrderProduct> _orderProductTable = new List<OrderProduct>();
        private OrderProduct _orderProduct = new OrderProduct();


        public int AddProductToOrder(int orderId, int productId)
        {
            int id = _db.Insert( $"insert into OrderProduct values (null, '{orderId}', '{productId}')");

            return id;

        }
        public List<Product> ListProductsOnOrder(int orderId)
        {
            List<Product> listOfProducts = new List<Product>();
            _db.Query($"SELECT * FROM Product INNER JOIN OrderProduct ON OrderId WHERE OrderId = {orderId}", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    listOfProducts.Add(new Product(){
                        ProductId = reader.GetInt32(0),
                        ProductType = reader[1].ToString(),
                        CustomerId = reader.GetInt32(2),
                        Title = reader[3].ToString(),
                        Description = reader[4].ToString(),
                        Price = reader.GetDouble(5),
                        Quantity = reader.GetInt32(6),
                        DateCreated = reader.GetDateTime(7)
                    });
                }
            });
            return listOfProducts;
        }
    }
}