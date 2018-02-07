using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;
/*  
    Author: Greg Turner
    Purpose: Testing OrderProduct manager methods
*/

namespace Bangazon.Tests

{
    public class OrderProductManagerShould
    {
        private OrderProduct _orderProduct;

        public OrderProductManagerShould()
        {
            // properties of OrderProduct for hard coding.

            _orderProduct = new OrderProduct(
                1,
                1,
                1
            );
        }
        [Fact]
        public void AddNewOrderProduct()
        {
            Assert.Equal(_orderProduct.Id, 1);
        }
    }
}

