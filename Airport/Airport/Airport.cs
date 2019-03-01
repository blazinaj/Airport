using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class Airport
    {
        private string _airportName;

        public string AirportName
        {
            get => _airportName;
            set
            {
                if (value.Length <= 3 && value.Length > 0)
                {
                    _airportName = value;
                }
                else
                {
                    Console.WriteLine("Airport name is longer than 3 letters!");
                }

            }
        }

        public Airport(string airportName)
        {
            AirportName = airportName;
        }
    }
}
