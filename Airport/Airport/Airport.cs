using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    public class Airport
    {
        private string _airportName;

        public string AirportName => _airportName;

        public Airport(string airportName)
        {
            if (airportName.Length <= 3 && airportName.Length > 0)
            {
                _airportName = airportName;
            }
            else
            {
                Console.WriteLine("Airport name: " + airportName + " is longer than 3 letters!");
            }
           
        }
    }
}
