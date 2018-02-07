using System;
using System.Collections.Generic;
using System.Linq;

namespace Bangazon
{
    public class ProductManager
    {
        private List<Product> _productList = new List<Product>();

        public void Add(Product product)
        {
            _productList.Add(product);
        }
        // public Product GetSingleProduct (int Id)
        // {
        //     return _product.Where(c => c.ProductId == Id).Single();
        // }

        public List<Product> ListProducts()
        {
            return _productList;
        }

        public void RemoveSingleProduct(Product product)
        {
            _productList.Remove(product);
        }

        public void UpdateSingleProduct(Product product)
        {
            product.ProductId = 2;
        }
    }
}