using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("1. Change the price associated with seats in a trip section");
            Console.WriteLine("2. Query the system for trips with available seats in a given class");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a trip");
            Console.WriteLine("5. Book a seat on a trip given only a seating preference");
            Console.WriteLine("6. Display Cruise Transportation System");
            Console.WriteLine("7. Save Cruise Transportation System to a file");
            Console.WriteLine("8. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 9)
            {

            }

            return DisplayMenu();
        }
    }
}
