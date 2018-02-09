using System;
using Bangazon;
using Bangazon.Menus;
using Bangazon.Managers;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {

            string prodPath = System.Environment.GetEnvironmentVariable("BANGAZON_CLI_DB");
            DatabaseConnection db = new DatabaseConnection(prodPath);

            DatabaseStartup databaseStartup = new DatabaseStartup(db);
            MainMenu menu = new MainMenu();

            int choice;
            // When the user enters the system show the main menu
            do {

                choice = menu.Show();

            // switch (choice)
            // {
            //     // case 1:
            //     // CreateCustomerMenu
            // }

            }
            while (choice != 9);
            menu.Show();
        }
    }
}