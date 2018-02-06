using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;

namespace Bangazon.Tests
{

 public class ProductManagerShould 
 {
      private Product _product;

    public ProductManagerShould() {
         _product = new Product(
            1, 
            1, 
            1, 
            "Bike",
            "Blue Bike",
            2.00,
            2
        );

    }

    [Fact]
    public void AddNewProduct()
    {
        Assert.Equal(_product.ProductId, 1);
    }

 }


}