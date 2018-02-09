using System;
using Bangazon;

namespace Bangazon.Menus
{

    public class MainMenu
    {
        public int Show()
        {

            // Console.Clear();
            // Seed the database if none exists
            // var db = new DatabaseConnection();
            // db.VerifyDataExists();

            Console.WriteLine ("*********************************************************");
            Console.WriteLine ("**  Welcome to Bangazon! Command Line Ordering System  **");
            Console.WriteLine ("*********************************************************");

            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. Choose active customer");
            Console.WriteLine ("3. Create a payment option");
            Console.WriteLine ("4. Add a product to active customer");
            Console.WriteLine ("5. Update active customer's product");
            Console.WriteLine ("6. Add product to shopping cart");
            Console.WriteLine ("7. Complete an order");
            Console.WriteLine ("8. View Reports");
            Console.WriteLine ("9. Leave Bangazon!");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);
            return choice;

            // MainMenu menu = new MainMenu();

            // If option 1 was chosen, create a new customer account
            // do {


            // }
        }
    }
}
