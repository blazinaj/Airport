using System;

namespace Airport
{
    public class Airline
    {
        private readonly string _airlineName;

        public string AirlineName => _airlineName;

        public Airline(string airlineName)
        {
           _airlineName = airlineName;
        }
    }
}