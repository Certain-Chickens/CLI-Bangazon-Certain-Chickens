using System;
using Bangazon.Managers;

namespace Bangazon.Menus
{

    public class CreateCustomer
    {
        public static void CreateCustomerMenu(CustomerManager cm){

            Console.Clear();
            Console.WriteLine ("Enter customer Full Name");
            Console.Write ("> ");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer Address");
            Console.Write ("> ");
            string address = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer City");
            Console.Write ("> ");
            string city = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer State");
            Console.Write ("> ");
            string state = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer Zip Code");
            Console.Write ("> ");
            string postalCode = Console.ReadLine();

            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();

                Customer person = new Customer()
                {
                    Name = name,
                    Address = address,
                    City = city,
                    State = state,
                    PostalCode = postalCode,
                    Phone = phoneNumber
                };
            cm.AddNewCustomer(person);

            Console.Clear();
            Console.WriteLine($"gg, {person.Name} is now in the Bangazon System");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}