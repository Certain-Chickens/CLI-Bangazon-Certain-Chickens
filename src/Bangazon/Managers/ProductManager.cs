using System;
using System.Collections.Generic;
using System.Linq;

namespace Bangazon
{
    public class ProductManager
    {
        private List<Product> _product = new List<Product>();


        public void Add(Product product)
        {
            _product.Add(product);
        }
        // public Product GetSingleProduct (int Id)
        // {
        //     return _product.Where(c => c.ProductId == Id).Single();
        // }

    }
}