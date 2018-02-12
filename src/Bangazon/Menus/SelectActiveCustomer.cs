using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Managers;

namespace Bangazon.Menus
{
    public class ActiveCustomer
    {
        public static void SelectActiveCustomer(CustomerManager cm)
        {

            //Select the customer that will be active from the List of customers
            Console.Clear();
            Console.WriteLine ("Which customer will be active?");
            
            //creating a variable to place the organized list of customers in the db
            var customerList = cm.ListCustomers().OrderBy(c => c.Name).ToList();

            //storing the customer in list form -- using dictionary instead of list to not overload the foreach loop in the 'Add' method. 
            Dictionary<int, Customer> customer = new Dictionary<int, Customer>();
            Console.Clear();
            int counter = 1; 

            //going through the list of customers and printing.
            foreach(Customer c in customerList)
            {
                customer.Add(counter, c);
                Console.WriteLine($"{counter}. {c.Name}");
                counter++;
            }

            Console.Write ("> ");
            Console.ReadKey();
            
            int choice = 0; 

            // selecting the customer from the list. 
            foreach(KeyValuePair<int, Customer> pair in customer)
            {
                if(choice == pair.Key)
                {
                    Console.Clear();
                    Console.WriteLine($"You selected {pair.Value.Name} in {pair.Value.City} {pair.Value.State} as the active customer");
                    CustomerManager.currentCustomer = pair.Value;
                    Console.WriteLine("To go back to the main menu, press any key.");
                    // Console.WriteLine("Press any key to continue.");
                    // if (choice == 1)
                    // {
                    //     Console.Clear();
                        
                    // }
                    Console.ReadKey();
                }
            }
        }
    }
}