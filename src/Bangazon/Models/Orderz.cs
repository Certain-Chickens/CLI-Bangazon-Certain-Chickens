using System;
/*  
    Author: Greg Turner
    Purpose: Orderz model schema and constructor
*/

namespace Bangazon
{
    // Define the class/table Orderz
    public class Orderz

    {
        // Orderz OrderId property/table column is an integer that can be read and changed
        public int OrderId { get; set; }
        /*  Orderz CustomerId property/table column is an integer that can be read and changed 
            (foreign key from Customer table) */
        public int CustomerId { get; set; }
         /*  Orderz PaymentTypeId property/table column is an integer that can be read and changed 
            (foreign key from PaymentType table) Note that it is not required until order is completed*/
        public int? PaymentTypeId { get; set; }
        // Orderz DateCreated property/table column is an string that can be read and changed
        public DateTime DateCreated { get; set; }
    }
}
