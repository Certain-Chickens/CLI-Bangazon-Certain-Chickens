using System;
using Bangazon.Managers;

namespace Bangazon.Menus
{

    public class CreatePaymentType
    {
        public static void CreatePaymentTypeMenu(PaymentTypeManager ptm){

            Console.Clear();
            //prompt user to enter payment information
            Console.WriteLine($"Enter payment type (e.g. AmEx, Visa, Checking)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write ("> ");
            Console.ResetColor();
            string paymentType = Console.ReadLine();

            int accountNumber = 0;
            //next prompts to enter account number
            do{
                try{
                    Console.WriteLine($"Enter Account Number");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write ("> ");
                    Console.ResetColor();
                    accountNumber = Convert.ToInt32(Console.ReadLine());
                    // int.TryParse(Console.ReadLine(), out accountNumber);
                }catch{
                    Console.WriteLine($"Enter Account Number");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write ("> ");
                    Console.ResetColor();
                    Int32.TryParse(Console.ReadLine(), out accountNumber);
                }

            } while (accountNumber == 0);

            // PaymentType newPaymentType = new CreatePaymentType () { PaymentTypeName=accountNumber, Name=name};
            // ptm.AddPaymentType(newPaymentType);
            // Console.WriteLine("Payment type added. Press any key to continue.");
            // Console.ReadLine();
        }
    }
}

