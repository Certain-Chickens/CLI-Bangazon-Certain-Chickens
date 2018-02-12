using System;
using System.Collections.Generic;
using System.Linq;
/*
    Author: Greg Turner
    Purpose: OrderProduct manager methods for OrderProduct data manipluation
*/

namespace Bangazon.Managers
{
    public class OrderProductManager
    {
        private List<OrderProduct> _orderProductTable = new List<OrderProduct>();
        private OrderProduct _orderProduct = new OrderProduct
        (
            0,
            0,
            0
        );

        public void Add(int orderId, int productId)
        {
            _orderProduct.OrderzId = orderId;
            _orderProduct.ProductId = productId; 
            _orderProductTable.Add(_orderProduct);

        }
        public List<OrderProduct> ListOrderProduct()
        {
            return _orderProductTable;
        }
    }
}