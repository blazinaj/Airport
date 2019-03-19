using System;
using System.Collections.Generic;
using System.Dynamic;
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
            Console.WriteLine("1. Create an Airport");
            Console.WriteLine("2. Create an Airline");
            Console.WriteLine("3. Create a Flight");
            Console.WriteLine("4. Create a Section");
            Console.WriteLine("5. Display Airport Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > 0 && res < 7)
            {
                // Create Airport
                if (res == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Creating an Airport...");
                    Console.WriteLine("Please enter the Airport name: ");
                    string airportName = Console.ReadLine();

                    string result = SystemManager.airFactory.CreatePort(airportName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Create Airline
                if (res == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Creating an Airline...");
                    Console.WriteLine("Please enter the Airline name: ");
                    string airlineName = Console.ReadLine();

                    string result = SystemManager.airFactory.CreateLine(airlineName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                // Create Flight
                if (res == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Creating a Flight...");
                    Console.WriteLine("Please enter Airline Name: ");
                    string airlineName = Console.ReadLine();

                    Console.WriteLine("Please enter Origination Airport: ");
                    string origAirport = Console.ReadLine();

                    Console.WriteLine("Please enter Destination Airport: ");
                    string distAirport = Console.ReadLine();

                    Console.WriteLine("Please enter FlightID: ");
                    string flightID = Console.ReadLine();

                    Console.WriteLine("Please enter Date and Time of the flight. Ex: mm/dd/yyyy/hh/mm ");
                    string dateTime = Console.ReadLine();

                    string[] dateTImeArray = dateTime.Split("/");

                    int month = int.Parse(dateTImeArray[0]);
                    int day = int.Parse(dateTImeArray[1]);
                    int year = int.Parse(dateTImeArray[2]);
                    int hour = int.Parse(dateTImeArray[3]);
                    int minutes = int.Parse(dateTImeArray[4]);

                    string result = SystemManager.airFactory.CreateTrip(airlineName, origAirport, distAirport, year, month, day, hour, minutes, flightID);
                    
                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                // Create Section
                if (res == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Creating a Flight Section...");
                    Console.WriteLine("Please enter Airline Name: ");
                    string airlineName = Console.ReadLine();

                    Console.WriteLine("Please enter FlightID: ");
                    string flightID = Console.ReadLine();

                    Console.WriteLine("Please enter Flight Class. Ex: E, F, B");
                    SeatClass flightClass = Enum.Parse<SeatClass>(Console.ReadLine());

                    Console.WriteLine("Please enter class price: ");
                    int price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter number of rows: ");
                    int numberRows = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter type of columns. Ex: S, M, W ");
                    char numberColn = Convert.ToChar(Console.ReadLine());

                    string result = SystemManager.airFactory.CreateSection(airlineName, flightID, numberRows, numberColn, flightClass, price);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                // Display
                if (res == 5)
                {
                    UserMenu.UserMenu menu = new AirportUserMenu();
                    menu.DisplaySystemDetails();
                }

                if (res == 6)
                {
                    UserMenu.UserMenu userMenu = new AirportUserMenu();
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
