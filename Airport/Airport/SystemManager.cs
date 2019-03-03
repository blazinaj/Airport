using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Airport
{
    public class SystemManager
    {
        List<Airport> airports = new List<Airport>();
        List<Airline> airlines = new List<Airline>();
        List<Flight> flights = new List<Flight>();

        public void CreateAirport(string n)
        {
            Airport airport = null;

            if (n.Length <= 3 && n.Length > 0)
            {
                airport = new Airport(n);
            }
            else
            {
                Console.WriteLine("Airport name: " + n + " is longer than 3 letters!");
            }

            List<Airport> results = airports.FindAll(x => airport != null && x.AirportName == airport.AirportName);

            if (results.Count > 0)
            {
                if (airport != null) Console.WriteLine("Airport name: " + airport.AirportName + " is already exists!");
            }
            else
            {
                airports.Add(airport);
            }

        }

        public void CreateAirline(string n)
        {
            Airline airline = new Airline(n);

            List<Airline> results = airlines.FindAll(x => x.AirlineName == airline.AirlineName);

            if (results.Count > 0)
            {
                Console.WriteLine("Airline name: " + airline.AirlineName + " is already exists!");
            }
            else
            {
                airlines.Add(airline);
            }
        }

        public void CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            if (orig.Equals(dest))
            {
                Console.WriteLine("For Flight: "+id+" Same Destination Airport");
            }
            else
            {
                Flight flight = new Flight(aname, orig, dest, year, month, day, id);

                flights.Add(flight);
            }
        }
        /*
                public static FlightSection CreateSection(string air, string flID, int rows, int cols, SeatClass s)
                {
                    return "";
                }
          */
    }
}
