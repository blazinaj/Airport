using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Menu;

namespace Transport.UserMenu
{
    class TrainUserMenu : UserMenu
    {
        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Train Transportation System");
            Console.WriteLine("Please choose one of the following from menu:");
            Console.WriteLine();
            Console.WriteLine("0. Create an Train System from a file");
            Console.WriteLine("1. Change the price associated with seats in a TrainJourney section");
            Console.WriteLine("2. Query the system for TrainJourney with available seats in a given class");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a TrainJourney");
            Console.WriteLine("5. Book a seat on a TrainJourney given only a seating preference");
            Console.WriteLine("6. Display Train Transportation System");
            Console.WriteLine("7. Save Train Transportation System to a file");
            Console.WriteLine("8. Go to the Admin Menu");
            Console.WriteLine("9. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 10)
            {
                if (res == 0)
                {
                    Console.Clear();
                    TrainImportFile.ReadFromFile();

                    Console.WriteLine("System was build from file successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 1)
                {
                    //Change the price associated with seats in a flight section
                    Console.Clear();

                    Console.WriteLine("Please enter the Train Journey ID:");
                    string trainID = Console.ReadLine();

                    var tripExist = SystemManager.trainInformation.DoesTripExist(trainID);

                    if (tripExist)
                    {
                        Console.WriteLine("Please enter the class and seat number. Ex: E5");
                        string seat = Console.ReadLine();

                        Console.WriteLine("Please enter new price");
                        int price = int.Parse(Console.ReadLine());

                        foreach (var tripSection in SystemManager.trainInformation.TripSectionList.Where(x =>
                            (x.seatClass.ToString() == seat.Substring(0, 1).ToUpper().ToString()) && (x.tripId == trainID)))
                        {
                            tripSection.price = price;
                        }

                    }

                    Console.WriteLine("Price was changed successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();

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
                    //Display Train Transportation System
                    DisplaySystemDetails();
                    
                }

                if (res == 7)
                {
                    //Save Airport Transportation System to a file
                    SystemManager.trainInformation.SaveToFile();
                }

                if (res == 8)
                {
                    // Go to administrator menu
                    SystemMenu adminMenu = new TrainMenu();
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

        public override void DisplaySystemDetails()
        {
            Console.Clear();
            Console.WriteLine("List of Train Stations: ");
            foreach (var trainPort in SystemManager.trainInformation.PortList)
            {
                Console.WriteLine(trainPort.Name);
            }

            Console.WriteLine("List of Train lines: ");
            foreach (var trainLine in SystemManager.trainInformation.LineList)
            {
                Console.WriteLine(trainLine.Name);
            }

            Console.WriteLine("List of Train Trips: ");
            foreach (var trainTrips in SystemManager.trainInformation.TripList)
            {
                Console.WriteLine("Trip Number: " + trainTrips.TripID + " Train line Name: " + trainTrips.TripLine.Name +
                                  " Origin Station: " + trainTrips.OriginPort.Name + " Destination Station: " +
                                  trainTrips.DestinationPort.Name + " Date: " + trainTrips.Month + "/" + trainTrips.Day +
                                  "/" + trainTrips.Year);
            }

            Console.WriteLine("List of Trip Sections: ");
            foreach (var section in SystemManager.trainInformation.TripSectionList)
            {
                Console.WriteLine("Train Section " + section.seatClass.ToString() + " class for trip number " + section.tripId + " on " + section.line + " train line with " + section.rows + " rows and " + section.rows + " columns.");
            }

            Console.WriteLine("List of Seats: ");
            foreach (var seat in SystemManager.trainInformation.BookedSeatsList)
            {
                Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and trip number " + seat.TripId + " Is Booked: " + seat.IsBooked);
            }

            Console.WriteLine("\nPress Enter to Return to MENU");
            Console.ReadLine();
        }
    }
}
