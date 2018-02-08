using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;

namespace Bangazon.Managers.Tests
{

 public class ProductManagerShould
 {
      private Product _product;
      private Product _product2;

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
        _product2 = new Product(
            2,
            1,
            1,
            "Horse",
            "Blue Horse",
            3.00,
            4
        );

    }

    [Fact]
    public void AddProductProperties()
    {
        Assert.Equal(_product.ProductId, 1);
    }


    [Fact]
    public void ListAllProducts()
    {
        ProductManager productmanager = new ProductManager();
        productmanager.Add(_product);
        List<Product> listproduct = productmanager.ListProducts();
        Assert.Contains(_product, listproduct);
    }

    [Fact]
    public void RemoveProduct()
    {
        ProductManager productmanager = new ProductManager();
        productmanager.Add(_product);

        Product removedProduct = productmanager.RemoveSingleProduct(1);

        List<Product> updatedList = productmanager.ListProducts();

        Assert.DoesNotContain(removedProduct, updatedList);
    }

    [Fact]
    public void GetSingleProduct()
    {
        ProductManager productmanager = new ProductManager();
        productmanager.Add(_product);

        Product singleProduct = productmanager.GetSingleProduct(1);

        Assert.Equal(singleProduct.ProductId, 1);
    }

    // [Fact]
    // public void UpdateProduct()
    // {

    //     // Pass in Properties


    //     ProductManager productmanager = new ProductManager();
    //     productmanager.Add(_product);
    //     // productmanager.UpdateSingleProduct(_product);
    //     Product singleProduct = productmanager.GetSingleProduct(1);

    //     Assert.Equal(singleProduct.Title, "Motorcycle");
    // }
 }

}