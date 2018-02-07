using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;
/*  
    Author: Greg Turner
    Purpose: Testing Orderz manager methods
*/

namespace Bangazon.Tests

{
    public class OrderManagerShould
    {
        private Orderz _orderz;

        public OrderManagerShould()
        {
            // properties of Orderz for hard coding.

            _orderz = new Orderz(
                1,
                1,
                1,
                "2017-12-01"
            );
        }
        [Fact]
        public void AddNewOrderz()
        {
            Assert.Equal(_orderz.Id, 1);
        }

        [Fact]
        public void GetSingleOrderz()
        {
            OrderManager manager = new OrderManager();
            manager.Add(_orderz);
            Orderz orderz = manager.GetSingleOrderz(1);

            Assert.Equal(orderz.Id, 1);
        }

        [Fact]
        public void ListOrderz()
        {
            OrderManager manager = new OrderManager();
            manager.Add(_orderz);
            List<Orderz> allOrderz = manager.ListOrderz();

            Assert.Contains(_orderz, allOrderz);
        }
    }
}

