namespace Bangazon
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        
        // Constructor for PaymentType
        public PaymentType(int id, string name, int accountNumber)
        {
            this.Id = id;
            this.Name = name;
            this.AccountNumber = accountNumber;
        }
    }
}