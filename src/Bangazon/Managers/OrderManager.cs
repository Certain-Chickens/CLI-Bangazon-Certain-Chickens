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

    }
}