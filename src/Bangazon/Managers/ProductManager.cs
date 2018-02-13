using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
{
    public class ProductManager
    {
        // Makes a private DatabaseConnection variable named _db which will be used in the methods
        private DatabaseConnection _db;
        // set the private DatabaseConnection variable _db to equal a DatabaseConnection named db provided as an argument
        public ProductManager(DatabaseConnection db)
        {
            _db = db;
        }
        // private List<Product> _productList = new List<Product>();

        public int Add(Product product)
        {
            int id = _db.Insert( $"insert into Product values (null, '{product.ProductType}', '{product.CustomerId}','{product.Title}','{product.Description}','{product.Price}','{product.Quantity}','{product.DateCreated}')");

            return id;
        }

        // public List<Product> ListProducts()
        // {
        //     return _productList;
        // }

        // public Product RemoveSingleProduct(int id)
        // {
        //     var singleProduct = GetSingleProduct(id);

        //     _productList.RemoveAt(y);
        //     return singleProduct;
        // }

        public Product GetSingleProduct(int id)
        {
            Product singleProduct = new Product();
            _db.Query($"SELECT * FROM Product WHERE Product.ProductId = {id};", (SqliteDataReader reader) => {
                while (reader.Read()){
                singleProduct.ProductId = reader.GetInt32(0);
                singleProduct.ProductType = reader[1].ToString();
                singleProduct.CustomerId = reader.GetInt32(2);
                singleProduct.Title = reader[3].ToString();
                singleProduct.Description = reader[4].ToString();
                singleProduct.Price = reader.GetDouble(5);
                singleProduct.Quantity = reader.GetInt32(6);
                singleProduct.DateCreated = reader.GetDateTime(7);
                }
            });
            return singleProduct;
        }

        // public Product UpdateSingleProduct(int id)
        // {


        //     product.Title = "Motorcycle";
        //     _productList.Add(product);
        //     _productList.

        // }
    }
}