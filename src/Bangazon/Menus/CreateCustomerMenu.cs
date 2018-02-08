using System;
using Bangazon.Managers;

namespace Bangazon.Menus
{

    public class CreateCustomer
    {
        public static void CreateCustomerMenu(CustomerManager cm){

            Console.Clear();
            Console.WriteLine ("Enter customer first name");
            Console.Write ("> ");
            string firstName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");

            Console.Clear();
            string lastName = Console.ReadLine();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");

            Console.Clear();
            string city = Console.ReadLine();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");

            Console.Clear();
            string state = Console.ReadLine();
            Console.WriteLine ("Enter customer postal code");
            Console.Write ("> ");

            Console.Clear();
            string postalCode = Console.ReadLine();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();
        }
    }
}