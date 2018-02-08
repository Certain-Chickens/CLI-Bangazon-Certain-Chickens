using System;
using System.Collections.Generic;
using System.Linq;
/*  
    Author: Greg Turner
    Purpose: Orderz manager methods for Orderz data manipluation
*/

namespace Bangazon
{
    public class OrderManager
    {
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
        
        public Orderz CompleteOrderz(Orderz orderz, int payment, string dateCompleted)
        {   
            var completeOrderz = orderz;
            completeOrderz.PaymentTypeId = payment;
            completeOrderz.DateCompleted = dateCompleted;
            return completeOrderz; 
        }

    }
}