using System;
using Bangazon.Managers;

namespace Bangazon.Menus
{

    public class CreateCustomer
    {
        public static void CreateCustomerMenu(CustomerManager cm){

            //prompt user to enter customer full name
            Console.Clear();
            Console.WriteLine ("Enter customer Full Name");
            Console.Write ("> ");
            string name = Console.ReadLine();

            //prompt user to enter customer address
            Console.Clear();
            Console.WriteLine ("Enter customer Address");
            Console.Write ("> ");
            string address = Console.ReadLine();

            //prompt user to enter customer city
            Console.Clear();
            Console.WriteLine ("Enter customer City");
            Console.Write ("> ");
            string city = Console.ReadLine();

            //prompt user to enter customer state
            Console.Clear();
            Console.WriteLine ("Enter customer State");
            Console.Write ("> ");
            string state = Console.ReadLine();

            //prompt user to enter customer postal code
            Console.Clear();
            Console.WriteLine ("Enter customer Zip Code");
            Console.Write ("> ");
            string postalCode = Console.ReadLine();

            //prompt user to enter customer phone number
            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();

            //save all that info into strings and add them to the database
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