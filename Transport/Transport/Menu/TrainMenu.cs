using System;
using Transport.Menu;
using Transport.UserMenu;

namespace Transport
{
    internal class TrainMenu : SystemMenu
    {
        // Administrator user interface (UI)

        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Administrator Menu of the Train Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create a Train System from a file");
            Console.WriteLine("1. Create a Train Station");
            Console.WriteLine("2. Create a Train line");
            Console.WriteLine("3. Create a Train trip");
            Console.WriteLine("4. Save Train Transportation System to a file");
            Console.WriteLine("5. Display Train Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 4)
            {
                if (res == 0)
                {
                    Console.WriteLine("Creating an Train System from the File.in file ...");
                    //Create the initial airport system using information contained in an input file
                    CruiseImportFile.ReadFromFile();
                }

                if (res == 1)
                {
                    Console.WriteLine("Creating an Train Station...");
                    Console.WriteLine("Please enter the Train Station name: ");
                    string airportName = Console.ReadLine();

                //    (Port port, string result) = systemManager.airFactory.CreatePort(airportName);

               //     Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 2)
                {
                    Console.WriteLine("Creating an Train line...");
                    Console.WriteLine("Please enter the Train line name: ");
                    string airlineName = Console.ReadLine();

               //     (Line line, string result) = systemManager.airFactory.CreateLine(airlineName);

               //     Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 3)
                {
                    Console.WriteLine("Creating a Train trip...");
                    Console.WriteLine("Please enter the TripID: ");
                    string flightId = Console.ReadLine();

           //         Trip line = systemManager.airFactory.CreateTrip(flightId);

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 4)
                {
                    Console.WriteLine("Saving the Train System to the File.out file ...");

                    //Save Airport Transportation System to a file
                    SystemManager.trainInformation.SaveToFile();

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
                    UserMenu.UserMenu  userMenu = new TrainUserMenu();
                    userMenu.DisplayMenu();
                }
            }

            return DisplayMenu();
        }
    }
}