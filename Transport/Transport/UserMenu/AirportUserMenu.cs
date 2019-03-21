using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Menu;
using Transport.Trips;

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
                        var flight = SystemManager.airportInformation.TripList.Find(x => x.TripID == FlightID);

                        Console.WriteLine("Sections on Flight: " + flight.TripID);

                        var sections = SystemManager.airportInformation.TripSectionList.FindAll(x => x.tripId == FlightID);

                        foreach(var sec in sections)
                        {
                            Console.WriteLine("Seat Class : " + sec.seatClass + " Price: $" + sec.price);
                        }

                        Console.WriteLine("Please enter the section to change the price of:");
                        string section = Console.ReadLine();

                        Console.WriteLine("Please enter new price");
                        int price = int.Parse(Console.ReadLine());

                        foreach (var tripSection in SystemManager.airportInformation.TripSectionList.Where(x =>
                            (x.seatClass.ToString() == section.Substring(0,1).ToUpper().ToString()) && (x.tripId == FlightID)))
                        {
                            tripSection.price = price;
                        }
                        Console.WriteLine("Success: The price for Section " + section + " was successfully change to $" + price + "!");
                    }

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

                    Console.WriteLine("Please enter your Seat Class (F/B/E):");
                    string seatClass = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Available Seats for Flight " + origAirport + " to " + distAirport);

                    var avalibleFlight = SystemManager.airportInformation.TripList.Where(x =>
                        (x.OriginPort.Name == origAirport) && (x.DestinationPort.Name == distAirport));

                    foreach (var flight in avalibleFlight)
                    {
                        foreach (var section in SystemManager.airportInformation.TripSectionList.Where(x=> (x.line == flight.TripLine.Name) && (x.tripId == flight.TripID) && (x.seatClass.ToString() == seatClass)))
                        {
                            Console.WriteLine(section.seatClass + " class seats available");
                            var notBooked =section.seatList.Where(x => x.IsBooked == false);

                            foreach (var seat in notBooked)
                            {
                                Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and flight " + seat.TripId + " Is Booked: " + seat.IsBooked + " Price: $" + section.price);
                            }
                        }  
                    }
                    
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Change the seat class
                if (res == 3)
                {          
                    Console.WriteLine("Please enter the Airline Name. Ex: AMER");
                    string airline = Console.ReadLine();

                    var isAirlineExist = SystemManager.airportInformation.DoesLineExist(airline);

                    Console.WriteLine("Please enter the Origination Airport. Ex: GEG");
                    string origAirport = Console.ReadLine();

                    var isOrigPortExist = SystemManager.airportInformation.DoesPortExist(origAirport);

                    Console.WriteLine("Please enter the Destination Airport. Ex: LAX");
                    string destAirport = Console.ReadLine();

                    var isDestPortExist = SystemManager.airportInformation.DoesPortExist(destAirport);

                    Console.WriteLine("Please enter the class. Ex: Economy");
                    string seatClass = Console.ReadLine();

                    if (isAirlineExist && isOrigPortExist && isDestPortExist)
                    {
                        Console.WriteLine("Please enter new class price.");
                        int classPrice = int.Parse(Console.ReadLine());

                        var flight = SystemManager.airportInformation.TripList.Find(x => (x.TripLine.Name == airline) && (x.OriginPort.Name == origAirport) && (x.DestinationPort.Name == destAirport));

                        foreach (var section in SystemManager.airportInformation.TripSectionList.Where(x => seatClass != null && ((x.line == airline) && (x.tripId == flight.TripID) && (x.seatClass.ToString() == seatClass.Substring(0, 1).ToUpper()))))
                        {
                            section.price = classPrice;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong data entered!");
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Book a seat given a specific seat on a flight
                if (res == 4)
                {
                    
                    Console.WriteLine("Please enter the FlightID:");
                    string flightID = Console.ReadLine();

                    Console.WriteLine("Please enter a seat class (F/B/E)");
                    string seatClassString = Console.ReadLine();
                    SeatClass seatClassReal = SeatClass.E;
                    switch (seatClassString)
                    {
                        case "F":
                            seatClassReal = SeatClass.F;
                            break;
                        case "B":
                            seatClassReal = SeatClass.B;
                            break;
                        case "E":
                            seatClassReal = SeatClass.E;
                            break;
                        default:
                            Console.WriteLine("Invalid Seat Class");
                            break;
                    }

                    List<TripSection> sectionList = SystemManager.airportInformation.TripSectionList.FindAll(x => x.tripId == flightID);

                    TripSection section = sectionList.Find(x => x.seatClass.ToString() == seatClassString);
                    Console.WriteLine("Displaying all seats for that section");
                    Console.WriteLine(section.DisplaySeatDetails());

                    Console.WriteLine("Please enter a seat number: ");
                    string seatNumber = Console.ReadLine();
                    string column = seatNumber.ToCharArray().GetValue(0).ToString();
                    int row;
                    Int32.TryParse(seatNumber.ToCharArray().GetValue(1).ToString(), out row);
                    
                    try
                    {
                        string result = section.BookSeat(section.line, section.tripId, seatClassReal, row, char.Parse(column));
                        Console.WriteLine(result);
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Book a seat on a flight given only a seating preference
                if (res == 5)
                {
                    Console.WriteLine("Please enter the FlightID:");
                    string flightID = Console.ReadLine();

                    Console.WriteLine("Please enter the desired seat Class (F/B/E):");
                    string seatClassString = Console.ReadLine();
                    SeatClass seatClassReal = SeatClass.E;

                    switch (seatClassString)
                    {
                        case "F":
                            seatClassReal = SeatClass.F;
                            break;
                        case "B":
                            seatClassReal = SeatClass.B;
                            break;
                        case "E":
                            seatClassReal = SeatClass.E;
                            break;
                        default:
                            Console.WriteLine("Invalid Seat Class");
                            break;
                    }

                    Console.WriteLine("Please enter the desired Seating Preference ( W = window, A = aisle):");
                    string seatTypeInput = Console.ReadLine();
                    string seatTypeReal = "aisle";

                    switch (seatTypeInput)
                    {
                        case "W":
                            seatTypeReal = "window";
                            break;
                        case "A":
                            seatTypeReal = "aisle";
                            break;
                        default:
                            Console.WriteLine("Not a valid seat type.. defaulting to aisle seat..");
                            break;
                    }

                    var section = SystemManager.airportInformation.TripSectionList.Find(x => ((x.tripId == flightID) && (x.seatClass == seatClassReal)));

                    // Checks if trip exists
                    if (!SystemManager.airportInformation.DoesTripExist(flightID))
                    {
                        Console.WriteLine("Error: There is no trip " + flightID + " available!");
                    }

                    // Checks if section exists
                    else if (section == null)
                    {
                        Console.WriteLine("Error: There is no section " + seatClassString + " on flight " + flightID);
                    }

                    // If trip and section exist
                    else
                    {
                        // Find a seat with type preference and is not booked
                        Seat seat = section.seatList.Find(x => x.Type.ToString() == seatTypeReal && x.IsBooked == false);

                        // Checks if a seat with type preference exists
                        if (seat == null)
                        {
                            // If no seat with that type exists, looks for another one
                            Console.WriteLine("No available " + seatTypeReal + " seat found, checking for another seat..");
                            Seat anotherSeat = section.seatList.Find(x => x.IsBooked == false);

                            // No other seats exist
                            if (anotherSeat == null)
                            {
                                Console.WriteLine("No available seats at all, sorry. Have a nice day!");
                               
                            }
                            // Found another available seat
                            else
                            {
                                section.BookSeat(anotherSeat.Line, anotherSeat.TripId, section.seatClass, anotherSeat.RowNumber, anotherSeat.ColumnCharacter);
                                Console.WriteLine("Success: " + section.seatClass + " class " + seat.Type + " seat, number: " + seat.ColumnCharacter + seat.RowNumber + " was booked on trip " + flightID + " for $" + section.price + "!");

                            }
                        }
                        // If seat with original preference exists, book it.
                        else
                        {
                            section.BookSeat(seat.Line, seat.TripId, section.seatClass, seat.RowNumber, seat.ColumnCharacter);
                            Console.WriteLine("Success: " + section.seatClass + " class " + seat.Type + " seat, number: " + seat.ColumnCharacter + seat.RowNumber + " was booked on trip " + flightID + " for $" + section.price + "!");
                        }
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Display Airport Transportation System
                if (res == 6)
                {
                    DisplaySystemDetails();
                }

                //Save Airport Transportation System to a file
                if (res == 7)
                {
                    
                    SystemManager.airportInformation.SaveToFile("airport");
                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
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
                Console.WriteLine("Flight Section " + section.seatClass.ToString() + " class with section price $"+section.price+" for flight number " + section.tripId + " on " + section.line + " airline with " + section.rows + " rows and " + section.layout + " columns layout.");
                Console.WriteLine();

                //List seats in FlightSection
                Console.WriteLine("Seats in Section: " + section.seatClass.ToString());
                Console.WriteLine();

                Console.WriteLine(section.DisplaySeatDetails());
                Console.WriteLine();
            }


            Console.WriteLine("\nPress Enter to Return to MENU");
            Console.ReadLine();
        }
    }
}
