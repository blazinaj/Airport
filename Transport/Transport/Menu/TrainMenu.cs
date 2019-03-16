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
            Console.WriteLine("1. Create an Train Station");
            Console.WriteLine("2. Create an Train Journey");
            Console.WriteLine("3. Create a Trip");
            Console.WriteLine("4. Create a Section");
            Console.WriteLine("5. Display Train Transportation System");
            Console.WriteLine("6. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > 0 && res < 7)
            {
                if (res == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Creating an Train Station...");
                    Console.WriteLine("Please enter the Train Station name: ");
                    string trainStationName = Console.ReadLine();

                    string result = SystemManager.trainFactory.CreatePort(trainStationName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Creating a Train Journey...");
                    Console.WriteLine("Please enter the Train Journey name: ");
                    string rainJourneyName = Console.ReadLine();

                    string result = SystemManager.trainFactory.CreateLine(rainJourneyName);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Creating a Trip...");
                    Console.WriteLine("Please enter Train Journey Name: ");
                    string trainJourneyName = Console.ReadLine();

                    Console.WriteLine("Please enter Origination Station: ");
                    string origStation = Console.ReadLine();

                    Console.WriteLine("Please enter Destination Station: ");
                    string distStation = Console.ReadLine();

                    Console.WriteLine("Please enter TripID: ");
                    string tripID = Console.ReadLine();

                    Console.WriteLine("Please enter Date and Time of the flight. Ex: mm/dd/yyyy/hh/mm ");
                    string dateTime = Console.ReadLine();

                    string[] dateTImeArray = dateTime.Split("/");

                    int month = int.Parse(dateTImeArray[0]);
                    int day = int.Parse(dateTImeArray[1]);
                    int year = int.Parse(dateTImeArray[2]);
                    int hour = int.Parse(dateTImeArray[3]);
                    int minutes = int.Parse(dateTImeArray[4]);

                    string result = SystemManager.trainFactory.CreateTrip(trainJourneyName, origStation, distStation, year, month, day, hour, minutes, tripID);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 4)
                {
                    //Create Section
                    Console.Clear();
                    Console.WriteLine("Creating a Trip Section...");
                    Console.WriteLine("Please enter Train Journey Name: ");
                    string trainJourneyName = Console.ReadLine();

                    Console.WriteLine("Please enter TripID: ");
                    string tripID = Console.ReadLine();

                    Console.WriteLine("Please enter Train section Class. Ex: E, F, B");
                    SeatClass trainClass = Enum.Parse<SeatClass>(Console.ReadLine());

                    Console.WriteLine("Please enter class price: ");
                    int price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter number of rows: ");
                    int numberRows = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter type of columns. Ex: S, M, W ");
                    char numberColn = Convert.ToChar(Console.ReadLine());

                    string result = SystemManager.trainFactory.CreateSection(trainJourneyName, tripID, numberRows, numberColn, trainClass, price);

                    Console.WriteLine(result);
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 5)
                {
                    // Display Airport system call
                    UserMenu.UserMenu menu = new TrainUserMenu();
                    menu.DisplaySystemDetails();
                }

                if (res == 6)
                {
                    UserMenu.UserMenu userMenu = new TrainUserMenu();
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