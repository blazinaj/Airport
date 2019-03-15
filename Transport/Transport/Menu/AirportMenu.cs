using System;
using System.Collections.Generic;
using System.Text;
using Transport.Lines;
using Transport.UserMenu;

namespace Transport.Menu
{
    class AirportMenu : SystemMenu
    {
        // Administrator user interface (UI)

        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Administrator Menu of the Airport Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create an airport System from a file");
            Console.WriteLine("1. Create an Airport");
            Console.WriteLine("2. Create an Airline");
            Console.WriteLine("3. Create a Flight");
            Console.WriteLine("4. Save Airport Transportation System to a file");
            Console.WriteLine("5. Display Airport Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 7)
            {
                if (res == 0)
                {
                    Console.WriteLine("Creating an Airport System from the File.in file ...");
                    //Create the initial airport system using information contained in an input file
                    CruiseImportFile.ReadFromFile();
                }

                if (res == 1)
                {
                    Console.WriteLine("Creating an Airport...");
                    Console.WriteLine("Please enter the Airport name: ");
                    string airportName = Console.ReadLine();

                    string result = SystemManager.airFactory.CreatePort(airportName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 2)
                {
                    Console.WriteLine("Creating an Airline...");
                    Console.WriteLine("Please enter the Airline name: ");
                    string airlineName = Console.ReadLine();

 //                   (Line line, string result) = SystemManager.airFactory.CreateLine(airlineName);

//                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 3)
                {
                    Console.WriteLine("Creating a Flight...");
                    Console.WriteLine("Please enter the FlightID: ");
                    string flightId = Console.ReadLine();

//                    Trip line = SystemManager.airFactory.CreateTrip(flightId);

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 4)
                {
                    Console.WriteLine("Saving the Airport System to the File.out file ...");
                    // Code here

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 5)
                {
                    // Display Airport system call

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 6)
                {
                    UserMenu.UserMenu userMenu = new AirportUserMenu();
                    userMenu.DisplayMenu();
                }
            }

            return DisplayMenu();
        }
    }
}
