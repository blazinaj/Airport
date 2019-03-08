using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    public class Airport
    {
        private readonly string _airportName;

        internal string AirportName => _airportName;

        public Airport(string airportName)
        {
            _airportName = airportName;
        }

        public override string ToString()
        {
            return "Airport: " + _airportName;
        }
    }
}
