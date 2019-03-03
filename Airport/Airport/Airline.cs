using System;

namespace Airport
{
    public class Airline
    {
        private string _airlineName;

        public string AirlineName => _airlineName;

        public Airline(string airlineName)
        {
            if (airlineName.Length < 6)
            {
                _airlineName = airlineName;
            }
            else
            {
                Console.WriteLine("Airport name: " + airlineName + " is longer than 5 letters!");
            }

        }
    }
}