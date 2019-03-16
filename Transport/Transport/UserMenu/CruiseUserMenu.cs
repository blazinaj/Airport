using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Menu;

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
            Console.WriteLine("1. Change the price associated with seats in a CruiseTrip section");
            Console.WriteLine("2. Query the system for CruiseTrip with available seats in a given class");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a CruiseTrip");
            Console.WriteLine("5. Book a seat on a CruiseTrip given only a seating preference");
            Console.WriteLine("6. Display Cruise Transportation System");
            Console.WriteLine("7. Save Cruise Transportation System to a file");
            Console.WriteLine("8. Go to the Admin Menu");
            Console.WriteLine("9. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 10)
            {
                if (res == 0)
                {
                    Console.Clear();
                    CruiseImportFile.ReadFromFile();

                    Console.WriteLine("System was build from file successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 1)
                {
                    //Change the price associated with seats in a flight section
                    Console.Clear();


                    Console.WriteLine("Please enter the Cruise TripID:");
                    string tripID = Console.ReadLine();

                    var tripExist = SystemManager.cruiseInformation.DoesTripExist(tripID);

                    if (tripExist)
                    {
                        Console.WriteLine("Please enter the class and seat number. Ex: E5");
                        string seat = Console.ReadLine();

                        Console.WriteLine("Please enter new price");
                        int price = int.Parse(Console.ReadLine());

                        foreach (var tripSection in SystemManager.cruiseInformation.TripSectionList.Where(x =>
                            (x.seatClass.ToString() == seat.Substring(0, 1).ToUpper().ToString()) && (x.tripId == tripID)))
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
                    //Display Cruise Transportation System
                    Console.Clear();
                    Console.WriteLine("List of Cruises: ");
                    foreach (var cruise in SystemManager.cruiseInformation.PortList)
                    {
                        Console.WriteLine(cruise.Name);
                    }

                    Console.WriteLine("List of Cruise lines: ");
                    foreach (var cruiseline in SystemManager.cruiseInformation.LineList)
                    {
                        Console.WriteLine(cruiseline.Name);
                    }

                    Console.WriteLine("List of Cruise trips: ");
                    foreach (var trip in SystemManager.cruiseInformation.TripList)
                    {
                        Console.WriteLine("Cruise Number: " + trip.TripID + " Cruise line Name: " + trip.TripLine.Name +
                                          " Origin Port: " + trip.OriginPort.Name + " Destination Port: " +
                                          trip.DestinationPort.Name + " Date: " + trip.Month + "/" + trip.Day +
                                          "/" + trip.Year);
                    }

                    Console.WriteLine("List of Cruise Sections: ");
                    foreach (var section in SystemManager.cruiseInformation.TripSectionList)
                    {
                        Console.WriteLine("Cruise Section " + section.seatClass.ToString() + " class for cruise trip number " + section.tripId + " on " + section.line + " cruise line with " + section.rows + " rows and " + section.rows + " columns.");
                    }

                    Console.WriteLine("List of Seats: ");
                    foreach (var seat in SystemManager.cruiseInformation.BookedSeatsList)
                    {
                        Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and trip number " + seat.TripId + " Is Booked: " + seat.IsBooked);
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                if (res == 7)
                {
                    //Save Airport Transportation System to a file
                    SystemManager.cruiseInformation.SaveToFile();
                }

                if (res == 8)
                {
                    // Go to administrator menu
                    SystemMenu adminMenu = new CruiseMenu();
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
    }
}
