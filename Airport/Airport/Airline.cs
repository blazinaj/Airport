using System;
using System.Collections.Generic;

namespace Airport
{
    public class Airline
    {
        private readonly string _airlineName;

        public string AirlineName => _airlineName;
        public List<Flight> FlightList { get; set; }

        public Airline(string airlineName)
        {
           _airlineName = airlineName;
        }
    }
}