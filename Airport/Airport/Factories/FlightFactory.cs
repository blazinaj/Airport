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
            List<Airline> airlineResults = airlineList.FindAll(x => x.AirlineName == airlineName);
            List<Airport> airportOrigResults = airportList.FindAll(x => x.AirportName == originAirport);
            List<Airport> airportDestResults = airportList.FindAll(x => x.AirportName == destAirport);
            string result;

            // Invalid Airline
            if (airlineResults.Count < 1)
            {
                throw new InvalidAirlineException("Error: Could not Create Flight, " + airlineName + " is not a valid airline!");
            }
            // Invalid Origin Airport
            else if (airportOrigResults.Count < 1)
            {
                throw new InvalidAirportException("Error: Could not Create Flight, " + originAirport + " is not a valid airport!");
            }
            // Invalid Destination Airport
            else if (airportDestResults.Count < 1)
            {
                throw new InvalidAirportException("Error: Could not Create Flight, " + destAirport + " is not a valid airport!");
            }
            // Valid Airports and Airline
            else if (airlineResults.Count > 0 && airportOrigResults.Count > 0 && airportDestResults.Count > 0)
            {
                // If All List Checks Pass, call CreateFlight in Airline for other checks
                try
                {
                    result = airlineResults.Find(x => x.AirlineName == airlineName).CreateFlight(airlineName, originAirport, destAirport, year, month, day, id);
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
