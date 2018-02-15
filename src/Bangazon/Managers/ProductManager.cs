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
        private List<Product> _productList;

        public int Add(Product product)
        {
            int id = _db.Insert( $"insert into Product values (null, '{product.ProductType}', '{product.CustomerId}','{product.Title}','{product.Description}','{product.Price}','{product.Quantity}','{product.DateCreated}')");

            return id;
        }

        public List<Product> ListProducts()
        {
            List <Product> _productList = new List <Product>();
            _db.Query($"SELECT * FROM `Product` ", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    _productList.Add(new Product(){
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
            return _productList;
        }

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

        public Product UpdateSingleProduct(int productId, string fieldToChange, string change)
        {
            Product editedProduct = new Product();
            switch (fieldToChange)
            {
                case "ProductType":
                    _db.Update($"UPDATE product SET ProductType='{change}' WHERE productID = {productId}");
                    break;
                
                case "Title":
                    _db.Update($"UPDATE product SET Title='{change}' WHERE productID = {productId}");
                    break;

                case "Description":
                    _db.Update($"UPDATE product SET Description='{change}' WHERE productID = {productId}");
                    break;

                case "Price":
                    double newPrice = Convert.ToDouble(change);
                    _db.Update($"UPDATE product SET Price='{newPrice}' WHERE productID = {productId}");
                    break;

                case "Quantity":
                    int newQuantity = Convert.ToInt32(change);
                    _db.Update($"UPDATE product SET Quantity='{newQuantity}' WHERE productID = {productId}");
                    break;

                default:
                    break;

            }
            editedProduct = GetSingleProduct(productId);
            return editedProduct;
        }
    }
}