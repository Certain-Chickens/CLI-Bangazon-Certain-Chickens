//Author Kevin Haggerty

namespace Bangazon
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int CsutomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        // Constructor for Product
        public Product(int productid, int producttypeid, int customerid, string title, string description, double price, int quantity)
        {
            this.ProductId = productid;
            this.ProductTypeId = producttypeid;
            this.CsutomerId = customerid;
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}