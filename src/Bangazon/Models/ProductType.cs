namespace Bangazon
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductCategory { get; set; }
        
        // Constructor for PaymentType
        public ProductType(int id, string category)
        {
            this.ProductTypeId = id;
            this.ProductCategory = category;
        }
    }
}