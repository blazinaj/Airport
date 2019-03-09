using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Airport
{
    public class SystemManager : IDisplaySystemDetails
    {
        private List<Airport> airportList = new List<Airport>();
        private List<Airline> airlineList = new List<Airline>();

        const int REQUIRED_AIRPORT_NAME_LENGTH = 3;
        const int MAXIMUM_AIRLINE_NAME_LENGTH = 5;

        public string CreateAirport(string n)
        {
            Airport newAirport = null;
            string result;

            if (n.Length == REQUIRED_AIRPORT_NAME_LENGTH)
            {
                newAirport = new Airport(n);
            }
            else
            {
                result = "Error: Could not create Airport, name: " + n + " must be exactly 3 letters!";
                Console.WriteLine(result);
                return result;
            }

            List<Airport> results = airportList.FindAll(x => newAirport != null && x.AirportName == newAirport.AirportName);

            if (results.Count > 0)
            {
                result = "Error: Airport name: " + newAirport.AirportName + " already exists!";
                if (newAirport != null) Console.WriteLine(result);
                return result;
            }
            else
            {
                result = "Success: Airport " + newAirport.AirportName + " Created!";
                airportList.Add(newAirport);
                Console.WriteLine(result);
                return result;
            }
        }

        public string CreateAirline(string n)
        {
            Airline newAirline = null;
            string result;
            if (n.Length <= MAXIMUM_AIRLINE_NAME_LENGTH)
            {
                newAirline = new Airline(n);
            }
            else
            {
                result = "Error: Airline name: " + n + " is longer than " + MAXIMUM_AIRLINE_NAME_LENGTH + " letters!";
                Console.WriteLine(result);
                return result;
            }


            List<Airline> results = airlineList.FindAll(x => newAirline != null && x.AirlineName == newAirline.AirlineName);

            if (results.Count > 0)
            {
                result = "Error: Airline name: " + newAirline.AirlineName + " is already exists!";
                Console.WriteLine(result);
                return result;
            }
            else
            {
                airlineList.Add(newAirline);
                result = "Success: Airline " + newAirline.AirlineName + " Created!";
                Console.WriteLine(result);
                return result;
            }
            
        }

        public string CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {

            string result;

            // Checks SystemManager Lists
            if (airlineList.FindAll(x => x.AirlineName == aname).Count < 1)
            {
                result = "Error: Could not Create Flight, " + aname + " is not a valid airline!";
                Console.WriteLine(result);
                return result;
            }

            if (airportList.FindAll(x => x.AirportName == orig).Count < 1)
            {
                result = "Error: Could not Create Flight, " + orig + " is not a valid airport!";
                Console.WriteLine(result);
                return result;
            }

            if (airportList.FindAll(x => x.AirportName == dest).Count < 1)
            {
                result = "Error: Could not Create Flight, " + dest + " is not a valid airport!";
                Console.WriteLine(result);
                return result;
            }

            if (year < DateTime.Now.Year)
            {
                if ( month < DateTime.Now.Month)
                {
                    if (day < DateTime.Now.Day)
                    {
                        result = "Error: Could not Create past date Flight!";
                        Console.WriteLine(result);
                        return result;
                    }

                    result = "Error: Could not Create past date Flight!";
                    Console.WriteLine(result);
                    return result;
                }

                result = "Error: Could not Create past date Flight!";
                Console.WriteLine(result);
                return result;
            }

            if (airlineList.FindAll(x => x.AirlineName == aname).Count > 0 && airportList.FindAll(x => x.AirportName == orig).Count > 0 && airportList.FindAll(x => x.AirportName == dest).Count > 0)
            { 
                // If All List Checks Pass, call CreateFlight in Airline for other checks
                result = airlineList.FindAll(x => x.AirlineName == aname).Find(x => x.AirlineName == aname).CreateFlight(aname, orig, dest, year, month, day, id);
                Console.WriteLine(result);
                return result;
            }
            else
            {
                result = "Some weird error happened";
                Console.WriteLine("Some weird error happened");
                return result;
            }
 
        }

        public string CreateSection(string air, string flID, int rows, int cols, SeatClass s)
        {
            string result;
            if (airlineList.FindAll(x => x.AirlineName == air).Count < 1)
            {
                result = "Error: The Airline " + air + " Does Not Exist!";
                Console.WriteLine(result);
                return result;
            }

            if (rows > 100 || rows < 1)
            {
                result = "Error: You must have between 1 and 100 rows!";
                Console.WriteLine(result);
                return result;
            }

            if (cols > 10 || cols < 1)
            {
                result = "Error: You must have between 1 and 10 columns!";
                Console.WriteLine(result);
                return result;
            }

            if ((airlineList.Find(x => x.AirlineName == air).FlightList.FindAll(x => x.ID == flID).Count) < 1)
            {
                result = "Error: The Flight " + flID + " associated with the Airline " + air + " Does Not Exist!";
                Console.WriteLine(result);
                return result;
            }

            if ((airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).FlightSectionList.FindAll(x => x.seatClass == s)).Count > 0)
            {
                result = "Error: A flight section with Seat Class " + s + " already exists on Flight " + flID + " with " + air + " airline!";
                Console.WriteLine(result);
                return result;
            }

            result = airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).CreateFlightSection(air, flID, rows, cols, s);
            return result;
        }

        public string BookSeat(string air, string fl, SeatClass s, int row, char col)
        {
            string result;
            char column = Char.ToUpper(col);

            if (airlineList.FindAll(x => x.AirlineName == air).Count < 1)
            {
                result = "Error: The Airline " + air + " Does Not Exist!";
                Console.WriteLine(result);
                return result;
            }

            if ((airlineList.Find(x => x.AirlineName == air).FlightList.FindAll(x => x.ID == fl).Count) < 1)
            {
                result = "Error: The Flight " + fl + " associated with the Airline " + air + " Does Not Exist!";
                Console.WriteLine(result);
                return result;
            }

            //check column for range between 'A' to 'J' 
            if ((column - 0) < 64 && (column - 0) > 75)
            {
                result = "Error: The Flight " + fl + " associated with the Airline " + air + ", the column greater than 'J' ";
                Console.WriteLine(result);
                return result;
            }

            if (row < 1)
            {
                result = "Error: The Flight " + fl + " associated with the Airline " + air + ", the row less than 1 ";
                Console.WriteLine(result);
                return result;
            }

            if ((airlineList.Find(x => x.AirlineName == air)
                    .FlightList.Find(x => x.ID == fl)
                    .FlightSectionList.Find(x => x.seatClass == s)
                    .BookedSeatsList.FindAll(x => (x.ColumnCharacter == col) && (x.ColumnCharacter == col) && (x.RowNumber == row) && (x.IsBooked == true)).Count) > 0)
            {
                result = "Error: The Flight " + fl + " associated with the Airline " + air + " and with seat " + col + row + " in " + s + " class" + " Already Booked!";
                Console.WriteLine(result);
                return result;
            }

            result = airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == fl).FlightSectionList.Find(x => x.seatClass == s).BookSeat(air, fl, s, row, column);
            return result;
        }

        public string DisplaySystemDetails()
        {
            string returnForUnitTests = "";

            Console.WriteLine("\nDisplaying Airport Information");
            Console.WriteLine("----------------------------------");
            foreach (var airport in airportList)
            {
                returnForUnitTests += airport.ToString();
                Console.WriteLine(airport.ToString());
            }
            Console.WriteLine("----------------------------------");

            Console.WriteLine("\nDisplaying Airline Information");
            Console.WriteLine("----------------------------------");
            foreach (var airline in airlineList)
            {
                airline.DisplaySystemDetails();
            }
            Console.WriteLine("----------------------------------");
            return returnForUnitTests;
        }

        public void FindAvailableFlights(string org, string dis)
        {
            Console.WriteLine("Available Seats for Flight " + org +" to "+ dis);
            foreach (var flight in airlineList)
            {
                foreach (var availableFlight in flight.FlightList.Where(x => (x.OriginAirport == org) && (x.DestinationAirport == dis)))
                {
                    foreach (var section in availableFlight.FlightSectionList)
                    {
                        Console.WriteLine(section.seatClass.ToString() + " class seats available");
                        var notBooked = section.BookedSeatsList.Where(x => x.IsBooked == false);

                        foreach (var seat in notBooked)
                        {
                            Console.WriteLine(seat.ToString());
                        }
                    }
                }
            }
        }

    }
}
