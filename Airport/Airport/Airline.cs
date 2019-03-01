using System;

namespace Airport
{
    public class Airline
    {
        private string _airlineName;

        public string AirlineName
        {
            get => _airlineName;
            set
            {
                if (value.Length < 6 && value.Length > 0)
                {
                    _airlineName = value;
                }
                else
                {
                    Console.WriteLine("Airline name is longer than 5 letters!");
                }
            }
        }

        public Airline(string airlineName)
        {
            AirlineName = airlineName;
        }
    }
}