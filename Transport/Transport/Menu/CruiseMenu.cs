using System;
using Transport.Menu;
using Transport.UserMenu;

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
            Console.WriteLine("1. Create a Port");
            Console.WriteLine("2. Create a Cruise line");
            Console.WriteLine("3. Create a Trip");
            Console.WriteLine("4. Create a Section");
            Console.WriteLine("5. Display Cruise Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > 0 && res < 7)
            {
                if (res == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Creating an Port...");
                    Console.WriteLine("Please enter the Port name: ");
                    string portName = Console.ReadLine();

                    string result = SystemManager.trainFactory.CreatePort(portName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Creating an Cruise line ...");
                    Console.WriteLine("Please enter the Cruise line name: ");
                    string cruiseLineName = Console.ReadLine();

                    string result = SystemManager.trainFactory.CreateLine(cruiseLineName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Creating a Trip...");
                    Console.WriteLine("Please enter Cruise line Name: ");
                    string airlineName = Console.ReadLine();

                    Console.WriteLine("Please enter Origination Port: ");
                    string origPort = Console.ReadLine();

                    Console.WriteLine("Please enter Destination Port: ");
                    string distPort = Console.ReadLine();

                    Console.WriteLine("Please enter TripID: ");
                    string tripID = Console.ReadLine();

                    Console.WriteLine("Please enter Date and Time of the trip. Ex: mm/dd/yyyy/hh/mm ");
                    string dateTime = Console.ReadLine();

                    string[] dateTimeArray = dateTime.Split("/");

                    int month = int.Parse(dateTimeArray[0]);
                    int day = int.Parse(dateTimeArray[1]);
                    int year = int.Parse(dateTimeArray[2]);
                    int hour = int.Parse(dateTimeArray[3]);
                    int minutes = int.Parse(dateTimeArray[4]);

                    string result = SystemManager.trainFactory.CreateTrip(airlineName, origPort, distPort, year, month, day, hour, minutes, tripID);
                    Console.WriteLine("Cruise trip was successfully created");

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 4)
                {
                    //Create Section
                    Console.Clear();
                    Console.WriteLine("Creating a Ship Section...");
                    Console.WriteLine("Please enter Cruise line Name: ");
                    string cruiseLineName = Console.ReadLine();

                    Console.WriteLine("Please enter TripID: ");
                    string tripID = Console.ReadLine();

                    Console.WriteLine("Please enter Trip Class. Ex: E, F, B");
                    SeatClass tripClass = Enum.Parse<SeatClass>(Console.ReadLine());

                    Console.WriteLine("Please enter class price: ");
                    int price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter number of rows: ");
                    int numberRows = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter type of columns. Ex: S, M, W ");
                    char numberColn = Convert.ToChar(Console.ReadLine());

                    string result = SystemManager.cruiseFactory.CreateSection(cruiseLineName, tripID, numberRows, numberColn, tripClass, price);
                    Console.WriteLine("Section was successfully created");

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 5)
                {
                    // Display Airport system call
                    UserMenu.UserMenu menu = new CruiseUserMenu();
                    menu.DisplaySystemDetails();
                }

                if (res == 6)
                {
                    UserMenu.UserMenu userMenu = new CruiseUserMenu();
                    userMenu.DisplayMenu();
                }
            }
            else
            {
                Console.WriteLine("Wrong number, please try again!");
            }

            return DisplayMenu();
        }
    }
}