using System;
using System.Collections.Generic;
using System.Linq;
/*
    Author: Greg Turner
    Purpose: Orderz manager methods for Orderz data manipluation
*/

namespace Bangazon.Managers
{
    public class OrderManager
    {
        // private Orderz _orderz = new Orderz
        // (
        //     1,
        //     1,
        //     0,
        //     ""
        // );
        private List<Orderz> _orderzTable = new List<Orderz>();

        public void Add(Orderz ticket)
        {
            _orderzTable.Add(ticket);
        }
        public Orderz GetSingleOrderz(int Id)
        {
            return _orderzTable.Where(o => o.Id == Id).Single();
        }

        public List<Orderz> ListOrderz()
        {
            return _orderzTable;
        }

        // Author: Leah Duvic and Greg Turner
        // Purpose: Completing customer order by adding the payment type.

        public Orderz CompleteOrderz(int OrderId, int paymentTypeId, string dateCompleted)
        {
            // _orderzTable.Add(_orderz);
            var completeOrderz = GetSingleOrderz(OrderId);
            var x = _orderzTable.IndexOf(completeOrderz);
            completeOrderz.PaymentTypeId = paymentTypeId;
            completeOrderz.DateCompleted = dateCompleted;
            _orderzTable[x] = completeOrderz;
            Console.WriteLine(_orderzTable);
            return _orderzTable[x];
        }

    }
}