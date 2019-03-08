using Airport.Exceptions;
using Airport.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport
{
    public class SystemManager : IDisplaySystemDetails
    {
        private List<Airport> airportList = new List<Airport>();
        private List<Airline> airlineList = new List<Airline>();

        private AirportFactory airportFactory = new AirportFactory();
        private AirlineFactory airlineFactory = new AirlineFactory();

        public string CreateAirport(string n)
        {
            try
            {
                (Airport airport, string success) = airportFactory.CreateAirport(n, airportList);

                airportList.Add(airport);

                Console.WriteLine(success);
                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            };
        }

        public string CreateAirline(string n)
        {
            try
            {
                (Airline airline, string success) = airlineFactory.CreateAirline(n, airlineList);

                airlineList.Add(airline);

                Console.WriteLine(success);
                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public string CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            List<Airline> airlineResults = airlineList.FindAll(x => x.AirlineName == aname);
            List<Airport> airportOrigResults = airportList.FindAll(x => x.AirportName == orig);
            List<Airport> airportDestResults = airportList.FindAll(x => x.AirportName == dest);

            string result;

            // Checks SystemManager Lists
            if (airlineResults.Count < 1)
            {
                result = "Error: Could not Create Flight, " + aname + " is not a valid airline!";
                Console.WriteLine(result);
                return result;
            }
            else if (airportOrigResults.Count < 1)
            {
                result = "Error: Could not Create Flight, " + orig + " is not a valid airport!";
                Console.WriteLine(result);
                return result;
            }
            else if (airportDestResults.Count < 1)
            {
                result = "Error: Could not Create Flight, " + dest + " is not a valid airport!";
                Console.WriteLine(result);
                return result;
            }
            else if (airlineResults.Count > 0 && airportOrigResults.Count > 0 && airportDestResults.Count > 0)
            { 
                // If All List Checks Pass, call CreateFlight in Airline for other checks
                result = airlineResults.Find(x => x.AirlineName == aname).CreateFlight(aname, orig, dest, year, month, day, id);
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

            if ((col - 'A') < 0 && (col - 'A') > 9)
            {
                result = "Error: The Flight " + fl + " associated with the Airline " + air + ", the column greater than 'J' ";
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

            result = airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == fl).FlightSectionList.Find(x => x.seatClass == s).BookSeat(air, fl, s, row, col);
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
