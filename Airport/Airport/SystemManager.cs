using System;
using System.Collections.Generic;

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
            Airline airline = null;

            if (n.Length < 6)
            {
                airline = new Airline(n);
            }
            else
            {
                Console.WriteLine("Airport name: " + n + " is longer than 5 letters!");
            }


            List<Airline> results = airlines.FindAll(x => airline != null && x.AirlineName == airline.AirlineName);

            if (results.Count > 0)
            {
                if (airline != null) Console.WriteLine("Airline name: " + airline.AirlineName + " is already exists!");
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

        public void CreateSection(string air, string flID, int rows, int cols, SeatClass s)
        {
           FlightSection flightSection = new FlightSection(air, flID, rows, cols, s);
        }

        public void BookSeat(string air, string fl, SeatClass s, int row, char col)
        {

        }

        public void DisplaySystemDetails()
        {

        }

        public void FindAvailableFlights(string den, string lon)
        {

        }
    }
}
