﻿using System;
using System.Collections.Generic;

namespace Airport
{
    public class SystemManager
    {
        List<Airport> airportList = new List<Airport>();
        List<Airline> airlines = new List<Airline>();
        List<Flight> flights = new List<Flight>();

        public void CreateAirport(string n)
        {
            Airport newAirport = null;

            if (n.Length == 3)
            {
                newAirport = new Airport(n);
            }
            else
            {
                Console.WriteLine("Could not create Airport, name: " + n + " must be exactly 3 letters!");
                return;
            }

            List<Airport> results = airportList.FindAll(x => newAirport != null && x.AirportName == newAirport.AirportName);

            if (results.Count > 0)
            {
                if (newAirport != null) Console.WriteLine("Airport name: " + newAirport.AirportName + " already exists!");
                return;
            }
            else
            {
                airportList.Add(newAirport);
                Console.WriteLine("Airport " + newAirport.AirportName + " Successfully Created!");
            }
        }

        public void CreateAirline(string n)
        {
            Airline newAirline = null;

            if (n.Length < 6)
            {
                newAirline = new Airline(n);
            }
            else
            {
                Console.WriteLine("Airline name: " + n + " is longer than 5 letters!");
                return;
            }


            List<Airline> results = airlines.FindAll(x => newAirline != null && x.AirlineName == newAirline.AirlineName);

            if (results.Count > 0)
            {
                Console.WriteLine("Airline name: " + newAirline.AirlineName + " is already exists!");
                return;
            }
            else
            {
                airlines.Add(newAirline);
                Console.WriteLine("Airline " + newAirline.AirlineName + " Successfully Created!");
            }
            
        }

        public void CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            if (orig.Equals(dest))
            {
                Console.WriteLine("For Flight: "+ id +" Same Destination Airport");
            }
            else
            {
                List<Airline> airlineResults = airlines.FindAll(x => x.AirlineName == aname);
                List<Airport> airportOrigResults = airportList.FindAll(x => x.AirportName == orig);
                List<Airport> airportDestResults = airportList.FindAll(x => x.AirportName == dest);

                if (airlineResults.Count > 0 && airportOrigResults.Count > 0 && airportDestResults.Count > 0)
                { 
                    Flight flight = new Flight(aname, orig, dest, year, month, day, id);
                    flights.Add(flight);
                }
                else
                {
                    Console.WriteLine("Invalid Airport or Airline");
                }
 
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
