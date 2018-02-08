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


        public void Add(OrderProduct lineItem)
        {
            _orderProductTable.Add(lineItem);
        }
        public List<OrderProduct> ListOrderProduct()
        {
            return _orderProductTable;
        }

    }
}