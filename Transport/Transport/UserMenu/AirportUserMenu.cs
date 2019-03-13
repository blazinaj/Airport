using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.UserMenu
{
    class AirportUserMenu : UserMenu
    {
        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Airport Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create an airport System from a file");
            Console.WriteLine("1. Change the price associated with seats in a flight section");
            Console.WriteLine("2. Query the system for flights with available seats in a given class ");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a flight");
            Console.WriteLine("5. Book a seat on a flight given only a seating preference");
            Console.WriteLine("6. Display Airport Transportation System");
            Console.WriteLine("7. Save Airport Transportation System to a file");
            Console.WriteLine("8. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 9)
            {

            }

            return DisplayMenu();
        }
    }
}
