using System;
/*  
    Author: Greg Turner
    Purpose: OrderProduct model joiner table schema and constructor
*/
namespace Bangazon
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderzId { get; set; }

        // Constructor for OrderProduct
        public OrderProduct
        (int id, int productId, int orderzId)
        {
            this.Id = id;
            this.ProductId = productId;
            this.OrderzId = orderzId;
        }
    }
}
