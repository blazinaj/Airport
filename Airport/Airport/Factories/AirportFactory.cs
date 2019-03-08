using Airport.Exceptions;
using System;
using System.Collections.Generic;

namespace Airport
{
    internal class AirportFactory
    {
        const int REQUIRED_AIRPORT_NAME_LENGTH = 3;

        public (Airport, string) CreateAirport(string n, List<Airport> airportList)
        {
            Airport newAirport = null;
            string result;

            if (n.Length == REQUIRED_AIRPORT_NAME_LENGTH)
            {
                newAirport = new Airport(n);
            }
            else
            {
                throw new AirportNameException("Error: Could not create Airport, name: " + n + " must be exactly 3 letters!");
            }

            // Checking to see if Airport Exists
            List<Airport> results = airportList.FindAll(x => newAirport != null && x.AirportName == newAirport.AirportName);

            if (results.Count > 0)
            {
                throw new AirportAlreadyExistsException("Error: Airport name: " + newAirport.AirportName + " already exists!");
            }
            else
            {
                result = "Success: Airport " + newAirport.AirportName + " Created!";
                return (newAirport, result);
            }
        }
    }
}