using Airport.Exceptions;
using Airport.Exceptions.Airline;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Factories
{
    class FlightFactory
    {
        public string CreateFlight(
            string airlineName, 
            string originAirport, 
            string destAirport, 
            int year, 
            int month, 
            int day, 
            string id, 
            List<Airport> airportList, 
            List<Airline> airlineList)
        {
            string result;

            // Invalid Airline
            if (airlineList.FindAll(x => x.AirlineName == airlineName).Count < 1)
            {
                throw new InvalidAirlineException("Error: Could not Create Flight, " + airlineName + " is not a valid airline!");
            }

            // Invalid Origin Airport
            if (airportList.FindAll(x => x.AirportName == originAirport).Count < 1)
            {
                throw new InvalidAirportException("Error: Could not Create Flight, " + originAirport + " is not a valid airport!");
            }
            
            // Invalid Destination Airport
            if (airportList.FindAll(x => x.AirportName == destAirport).Count < 1)
            {
                throw new InvalidAirportException("Error: Could not Create Flight, " + destAirport + " is not a valid airport!");
            }

            if (year < DateTime.Now.Year)
            {
                if (month < DateTime.Now.Month)
                {
                    if (day < DateTime.Now.Day)
                    {
                        throw new InvalidAirportException("Error: Could not Create Flight for past day!");
                    }

                    throw new InvalidAirportException("Error: Could not Create Flight for past month!");
                }

                throw new InvalidAirportException("Error: Could not Create Flight for past year!");
            }

            // Valid Airports and Airline
            if (airportList.FindAll(x => x.AirportName == originAirport).Count > 0 && airportList.FindAll(x => x.AirportName == originAirport).Count > 0 && airportList.FindAll(x => x.AirportName == destAirport).Count > 0)
            {
                // If All List Checks Pass, call CreateFlight in Airline for other checks
                try
                {
                    result = airlineList.FindAll(x => x.AirlineName == airlineName).Find(x => x.AirlineName == airlineName).CreateFlight(airlineName, originAirport, destAirport, year, month, day, id);
                }
                catch (InvalidFlightException e)
                {
                    throw new InvalidFlightException(e.Message);
                }
            }
            else
            {
                result = "Some weird error happened";
            }

            return result;
        }
    }
}
