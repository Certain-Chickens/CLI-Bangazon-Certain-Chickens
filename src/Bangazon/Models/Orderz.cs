using System;
/*  
    Author: Greg Turner
    Purpose: Orderz model schema and constructor
*/

namespace Bangazon
{
    public class Orderz

    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
        public string DateCompleted { get; set; }

        // Constructor for Orderz
        public Orderz
        (int id, int customerId, int paymentTypeId, string dateCompleted)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.PaymentTypeId = paymentTypeId;
            this.DateCompleted = dateCompleted;
        }
    }
}
