using System;
using System.Collections.Generic;
using System.Text;
using Transport.Lines;

namespace Transport.Menu
{
    class AirportMenu : SystemMenu
    {
        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Airport Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine("1. Create an Airport");
            Console.WriteLine("2. Create an Airline");
            Console.WriteLine("3. Create a Flight");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > 0 && res < 4)
            {
                if (res == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the Airport name: ");
                    string airportName = Console.ReadLine();

                    Port airPort = new AirPort(airportName);
                }

                if (res == 2)
                {
                    //Line airport = new AirLine();
                }
            }

            return "";
        }
    }
}
