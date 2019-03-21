using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Menu;
using Transport.Trips;

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
                    Console.Clear();

                    Console.WriteLine("Please enter the TripID:");
                    string TripID = Console.ReadLine();

                    var tripExist = SystemManager.cruiseInformation.DoesTripExist(TripID);

                    if (tripExist)
                    {
                        var trip = SystemManager.cruiseInformation.TripList.Find(x => x.TripID == TripID);

                        Console.WriteLine("Sections on Trip: " + trip.TripID);

                        var sections = SystemManager.cruiseInformation.TripSectionList.FindAll(x => x.tripId == TripID);

                        foreach (var sec in sections)
                        {
                            Console.WriteLine("Seat Class : " + sec.seatClass + " Price: $" + sec.price);
                        }

                        Console.WriteLine("Please enter the section to change the price of:");
                        string section = Console.ReadLine();

                        Console.WriteLine("Please enter new price");
                        int price = int.Parse(Console.ReadLine());

                        foreach (var tripSection in SystemManager.cruiseInformation.TripSectionList.Where(x =>
                            (x.seatClass.ToString() == section.Substring(0, 1).ToUpper().ToString()) && (x.tripId == TripID)))
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

                    Console.WriteLine("Please enter Origination Port. Ex: SEA");
                    string origPort = Console.ReadLine();

                    Console.WriteLine("Please enter Destination Port. Ex: LAX");
                    string distPort = Console.ReadLine();

                    Console.WriteLine("Please enter your Seat Class (F/B/E):");
                    string seatClass = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Available Seats for Trip " + origPort + " to " + distPort);

                    var avalibleTrip = SystemManager.cruiseInformation.TripList.Where(x =>
                        (x.OriginPort.Name == origPort) && (x.DestinationPort.Name == distPort));

                    foreach (var trip in avalibleTrip)
                    {
                        foreach (var section in SystemManager.airportInformation.TripSectionList.Where(x => (x.line == trip.TripLine.Name) && (x.tripId == trip.TripID) && (x.seatClass.ToString() == seatClass)))
                        {
                            Console.WriteLine(section.seatClass + " class seats available");
                            var notBooked = section.seatList.Where(x => x.IsBooked == false);

                            foreach (var seat in notBooked)
                            {
                                Console.WriteLine("Seat " + seat.ColumnCharacter + seat.RowNumber + ", on " + seat.Line + " line and trip " + seat.TripId + " Is Booked: " + seat.IsBooked + " Price: $" + section.price);
                            }
                        }
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Change the seat class
                if (res == 3)
                {
                    Console.WriteLine("Please enter the  Cruise line Name. Ex: AMER");
                    string line = Console.ReadLine();

                    var isAirlineExist = SystemManager.cruiseInformation.DoesLineExist(line);

                    Console.WriteLine("Please enter the Origination Port. Ex: SEA");
                    string origPort = Console.ReadLine();

                    var isOrigPortExist = SystemManager.cruiseInformation.DoesPortExist(origPort);

                    Console.WriteLine("Please enter the Destination Port. Ex: LAX");
                    string destAirport = Console.ReadLine();

                    var isDestPortExist = SystemManager.cruiseInformation.DoesPortExist(destAirport);

                    Console.WriteLine("Please enter the class. Ex: Economy");
                    string seatClass = Console.ReadLine();

                    if (isAirlineExist && isOrigPortExist && isDestPortExist)
                    {
                        Console.WriteLine("Please enter new class price.");
                        int classPrice = int.Parse(Console.ReadLine());

                        var trip = SystemManager.cruiseInformation.TripList.Find(x => (x.TripLine.Name == line) && (x.OriginPort.Name == origPort) && (x.DestinationPort.Name == destAirport));

                        foreach (var section in SystemManager.cruiseInformation.TripSectionList.Where(x => seatClass != null && ((x.line == line) && (x.tripId == trip.TripID) && (x.seatClass.ToString() == seatClass.Substring(0, 1).ToUpper()))))
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

                //Book a seat given a specific seat on a trip
                if (res == 4)
                {

                    Console.WriteLine("Please enter the TripID:");
                    string tripID = Console.ReadLine();

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

                    List<TripSection> sectionList = SystemManager.cruiseInformation.TripSectionList.FindAll(x => x.tripId == tripID);

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
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }

                //Book a seat on a flight given only a seating preference
                if (res == 5)
                {
                    Console.WriteLine("Please enter the TripID:");
                    string tripID = Console.ReadLine();

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

                    var section = SystemManager.cruiseInformation.TripSectionList.Find(x => ((x.tripId == tripID) && (x.seatClass == seatClassReal)));

                    // Checks if trip exists
                    if (!SystemManager.cruiseInformation.DoesTripExist(tripID))
                    {
                        Console.WriteLine("Error: There is no trip " + tripID + " available!");
                    }

                    // Checks if section exists
                    else if (section == null)
                    {
                        Console.WriteLine("Error: There is no section " + seatClassString + " on flight " + tripID);
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
                                Console.WriteLine("Success: " + section.seatClass + " class " + seat.Type + " seat, number: " + seat.ColumnCharacter + seat.RowNumber + " was booked on trip " + tripID + " for $" + section.price + "!");

                            }
                        }
                        // If seat with original preference exists, book it.
                        else
                        {
                            section.BookSeat(seat.Line, seat.TripId, section.seatClass, seat.RowNumber, seat.ColumnCharacter);
                            Console.WriteLine("Success: " + section.seatClass + " class " + seat.Type + " seat, number: " + seat.ColumnCharacter + seat.RowNumber + " was booked on trip " + tripID + " for $" + section.price + "!");
                        }
                    }

                    Console.WriteLine("\nPress Enter to Return to MENU");
                    Console.ReadLine();
                }



                if (res == 6)
                {
                    //Display Cruise Transportation System
                    DisplaySystemDetails();
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

        public override void DisplaySystemDetails()
        {
            Console.Clear();
            Console.WriteLine("List of Ports: ");
            foreach (var station in SystemManager.cruiseInformation.PortList)
            {
                Console.WriteLine(station.Name);
            }

            Console.WriteLine("List of Cruise lines: ");
            foreach (var line in SystemManager.cruiseInformation.LineList)
            {
                Console.WriteLine(line.Name);
            }

            Console.WriteLine("List of Cruise Journeys: ");
            foreach (var trainLine in SystemManager.cruiseInformation.TripList)
            {
                Console.WriteLine("Journey Number: " + trainLine.TripID + " Cruise line Name: " + trainLine.TripLine.Name +
                                  " Origin Port: " + trainLine.OriginPort.Name + " Destination Port: " +
                                  trainLine.DestinationPort.Name + " Date: " + trainLine.Month + "/" + trainLine.Day +
                                  "/" + trainLine.Year);
            }

            Console.WriteLine("List of the Cruise Sections: ");
            foreach (var section in SystemManager.cruiseInformation.TripSectionList)
            {
                Console.WriteLine("Journey Section " + section.seatClass.ToString() + " class with section price $" + section.price + " for Journey number " + section.tripId + " on " + section.line + "  Cruise line with " + section.rows + " rows and " + section.layout + " columns layout.");
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
