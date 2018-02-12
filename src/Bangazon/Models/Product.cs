//Author Kevin Haggerty

using System;

namespace Bangazon
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }       
    }
}