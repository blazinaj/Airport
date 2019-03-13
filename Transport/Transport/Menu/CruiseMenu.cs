using System;
using Transport.Menu;

namespace Transport
{
    internal class CruiseMenu : SystemMenu
    {
        // Administrator user interface (UI)

        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Administrator Menu of the Cruise Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create a Cruise System from a file");
            Console.WriteLine("1. Create a Cruise port");
            Console.WriteLine("2. Create a Cruise line");
            Console.WriteLine("3. Create a Cruise trip");
            Console.WriteLine("4. Save Cruise Transportation System to a file");
            Console.WriteLine("5. Display Cruise Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 4)
            {
                if (res == 0)
                {
                    Console.WriteLine("Creating an Cruise System from the File.in file ...");
                    //Create the initial airport system using information contained in an input file
                    CruiseImportFile.ReadFromFile();
                }

                if (res == 1)
                {
                    Console.WriteLine("Creating an Cruise Station...");
                    Console.WriteLine("Please enter the Cruise Station name: ");
                    string airportName = Console.ReadLine();

                    //    (Port port, string result) = systemManager.airFactory.CreatePort(airportName);

                    //     Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 2)
                {
                    Console.WriteLine("Creating an Cruise line...");
                    Console.WriteLine("Please enter the Cruise line name: ");
                    string airlineName = Console.ReadLine();

                    //     (Line line, string result) = systemManager.airFactory.CreateLine(airlineName);

                    //     Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 3)
                {
                    Console.WriteLine("Creating a Cruise trip...");
                    Console.WriteLine("Please enter the CruiseID: ");
                    string flightId = Console.ReadLine();

                    //         Trip line = systemManager.airFactory.CreateTrip(flightId);

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 4)
                {
                    Console.WriteLine("Saving the Cruise System to the File.out file ...");
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
        //            Client.Main();
                }
            }

            return DisplayMenu();
        }
    }
}