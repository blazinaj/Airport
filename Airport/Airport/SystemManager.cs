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
        private FlightFactory flightFactory = new FlightFactory();
        private FlightSectionFactory flightSectionFactory = new FlightSectionFactory();

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
            try
            {
                string success = flightFactory.CreateFlight(aname, orig, dest, year, month, day, id, airportList, airlineList);
                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
 
        }

        public string CreateSection(string air, string flID, int rows, int cols, SeatClass s)
        {
           try
            {
                string success = flightSectionFactory.CreateSection(air, flID, rows, cols, s, airlineList);
                return success;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
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
