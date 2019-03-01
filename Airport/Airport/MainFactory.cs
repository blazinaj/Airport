using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Airport
{
    class MainFactory
    {
        public static Airport CreateAirport(string airportName)
        {
            Airport airport = new Airport(airportName);
            return airport;
        }

        public static Airline CreateAirline(string airlineName)
        {
            Airline airline = new Airline(airlineName);
            return airline;
        }

        public static Flight CreateFlight(string airlineName, string originatingAirport, string destinationAirport, int flightNumber)
        {
            return "";
        }

        public static FlightSection CreateFlightSection()
        {
            return "";
        }
    }
}
