using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Menu;

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
            Console.WriteLine("2. Query the system for flights with available seats in a given class");
            Console.WriteLine("3. Change the seat class");
            Console.WriteLine("4. Book a seat given a specific seat on a flight");
            Console.WriteLine("5. Book a seat on a flight given only a seating preference");
            Console.WriteLine("6. Display Airport Transportation System");
            Console.WriteLine("7. Save Airport Transportation System to a file");
            Console.WriteLine("8. Go to the Admin Menu");
            Console.WriteLine("9. Go to the Main Menu");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);

            if (res > -1 && res < 10)
            {
                if (res == 0)
                {   
                    Console.Clear();
                    AirportImportFile.ReadFromFile();

                    Console.WriteLine("System was build from file successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }


                //Change the price associated with seats in a flight section
                if (res == 1)
                {
                    Console.Clear();


                        Console.WriteLine("Please enter the FlightID:");
                        string FlightID = Console.ReadLine();

                        var tripExist = SystemManager.airportInformation.DoesTripExist(FlightID);

                        if (tripExist)
                        {
                            Console.WriteLine("Please enter the class and seat number. Ex: E5");
                            string seat = Console.ReadLine();

                            Console.WriteLine("Please enter new price");
                            int price = int.Parse(Console.ReadLine());

                            foreach (var tripSection in SystemManager.airportInformation.TripSectionList.Where(x =>
                                (x.seatClass.ToString() == seat.Substring(0,1).ToUpper().ToString()) && (x.tripId == FlightID)))
                            {
                                tripSection.price = price;
                            }

                        }

                    Console.WriteLine("Price was changed successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();

                }

                //Query the system for flights with available seats in a given class
                if (res == 2)
                {
                    Console.Clear();
                    
                    Console.WriteLine("Please enter Origination Airport. Ex: GEG");
                    string origAirport = Console.ReadLine();

                    Console.WriteLine("Please enter Destination Airport. Ex: LAX");
                    string distAirport = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Available Seats for Flight " + origAirport + " to " + distAirport);

                    var avalibleFlight = SystemManager.airportInformation.TripList.Where(x =>
                        (x.OriginPort.Name == origAirport) && (x.DestinationPort.Name == distAirport));

                    foreach (var flight in avalibleFlight)
                    {
                        foreach (var section in SystemManager.airportInformation.TripSectionList.Where(x=> (x.line == flight.TripLine.Name) && (x.tripId == flight.TripID)))
                        {
                            Console.WriteLine(section.seatClass + " class seats available");
                            var notBooked = SystemManager.airportInformation.BookedSeatsList.Where(x => x.IsBooked == false);

                            foreach (var seat in notBooked)
                            {
                                Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and flight " + seat.TripId + " Is Booked: " + seat.IsBooked);
                            }
                        }  
                    }

                    Console.WriteLine("Price was changed successfully");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Change the seat class
                if (res == 3)
                {
                    
                    Console.WriteLine("Please enter the FlightID:");
                    string flightID = Console.ReadLine();
                    SystemInformation system = new SystemInformation();

                    var flight = system.TripList.Where(x => x.TripID == flightID);

                }

                //Book a seat given a specific seat on a flight
                if (res == 4)
                {
                    
                    Console.WriteLine("Please enter the FlightID:");
                    string flightID = Console.ReadLine();
                    SystemInformation system = new SystemInformation();

                    var flight = system.TripList.Where(x => x.TripID == flightID);
                }

                //Book a seat on a flight given only a seating preference
                if (res == 5)
                {
                    
                }

                //Display Airport Transportation System
                if (res == 6)
                {
                    
                    DisplaySystemDetails();
                }

                //Save Airport Transportation System to a file
                if (res == 7)
                {
                    
                    SystemManager.airportInformation.SaveToFile();
                }

                // Go to administrator menu
                if (res == 8)
                {
                    
                    SystemMenu adminMenu = new AirportMenu();
                    adminMenu.DisplayMenu();
                }

                //Go to the Main Menu
                if (res == 9)
                {
                    
                    UserMenu userMenu = new ClientMenu();
                    userMenu.DisplayMenu();
                }

            }

            return DisplayMenu();
        }

        public override void DisplaySystemDetails()
        {
            Console.Clear();
            Console.WriteLine("List of Airports: ");
            foreach (var airport in SystemManager.airportInformation.PortList)
            {
                Console.WriteLine(airport.Name);
            }

            Console.WriteLine("List of Airlines: ");
            foreach (var airline in SystemManager.airportInformation.LineList)
            {
                Console.WriteLine(airline.Name);
            }

            Console.WriteLine("List of Flights: ");
            foreach (var airline in SystemManager.airportInformation.TripList)
            {
                Console.WriteLine("Flight Number: " + airline.TripID + " Airline Name: " + airline.TripLine.Name +
                                  " Origin Airport: " + airline.OriginPort.Name + " Destination Airport: " +
                                  airline.DestinationPort.Name + " Date: " + airline.Month + "/" + airline.Day +
                                  "/" + airline.Year);
            }

            Console.WriteLine("List of Flight Sections: ");
            foreach (var section in SystemManager.airportInformation.TripSectionList)
            {
                Console.WriteLine("Flight Section " + section.seatClass.ToString() + " class for flight number " + section.tripId + " on " + section.line + " airline with " + section.rows + " rows and " + section.rows + " columns.");
            }

            Console.WriteLine("List of Seats: ");
            foreach (var seat in SystemManager.airportInformation.BookedSeatsList)
            {
                Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and flight " + seat.TripId + " Is Booked: " + seat.IsBooked);
            }

            Console.WriteLine("\nPress Enter to Return to MENU");
            Console.ReadLine();
        }
    }
}
