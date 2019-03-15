using System;
using System.Collections.Generic;
using System.Text;
using Transport.Menu;

namespace Transport.UserMenu
{
    class CruiseUserMenu : UserMenu
    {
        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Cruise Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create an Cruise System from a file");
            Console.WriteLine("1. Change the price associated with seats in a CruiseTrip section");
            Console.WriteLine("2. Query the system for CruiseTrip with available seats in a given class");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a CruiseTrip");
            Console.WriteLine("5. Book a seat on a CruiseTrip given only a seating preference");
            Console.WriteLine("6. Display Cruise Transportation System");
            Console.WriteLine("7. Save Cruise Transportation System to a file");
            Console.WriteLine("8. Go to the Admin Menu");
            Console.WriteLine("9. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 9)
            {
                if (res == 0)
                {
                    CruiseImportFile.ReadFromFile();
                }

                if (res == 1)
                {
                    //Change the price associated with seats in a flight section
                }

                if (res == 2)
                {
                    //Query the system for flights with available seats in a given class
                }

                if (res == 3)
                {
                    //Change the seat class
                }

                if (res == 4)
                {
                    //Book a seat given a specific seat on a flight
                }

                if (res == 5)
                {
                    //Book a seat on a flight given only a seating preference
                }

                if (res == 6)
                {
                    //Display Airport Transportation System
                }

                if (res == 7)
                {
                    //Save Airport Transportation System to a file
                }

                if (res == 8)
                {
                    // Go to administrator menu
                    SystemMenu adminMenu = new CruiseMenu();
                    adminMenu.DisplayMenu();
                }

                if (res == 9)
                {
                    //Go to the Main Menu
                    UserMenu userMenu = new ClientMenu();
                    userMenu.DisplayMenu();
                }

            }

            return DisplayMenu();
        }
    }
}
