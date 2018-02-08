using System;
using System.Collections.Generic;
using System.Linq;

namespace Bangazon.Managers
{
    public class ProductManager
    {
        private List<Product> _productList = new List<Product>();

        public void Add(Product product)
        {
            _productList.Add(product);
        }

        public List<Product> ListProducts()
        {
            return _productList;
        }

        public Product RemoveSingleProduct(int id)
        {
            var singleProduct = GetSingleProduct(id);
            var y = _productList.IndexOf(singleProduct);

            _productList.RemoveAt(y);
            return singleProduct;
        }

        public Product GetSingleProduct(int id)
        {
            return _productList.Where(c => c.ProductId == id).Single();
        }

        // public Product UpdateSingleProduct(int id)
        // {


        //     product.Title = "Motorcycle";
        //     _productList.Add(product);
        //     _productList.

        // }
    }
}