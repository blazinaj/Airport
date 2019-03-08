using Airport.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Factories
{
    internal class AirlineFactory
    {
        const int MAXIMUM_AIRLINE_NAME_LENGTH = 5;
        public (Airline, string) CreateAirline(string n, List<Airline> airlineList)
        {
            Airline newAirline = null;
            string result;

            if (n.Length <= MAXIMUM_AIRLINE_NAME_LENGTH)
            {
                newAirline = new Airline(n);
            }
            else
            {
                throw new AirlineNameException("Error: Airline name: " + n + " is longer than " + MAXIMUM_AIRLINE_NAME_LENGTH + " letters!");
            }


            List<Airline> results = airlineList.FindAll(x => newAirline != null && x.AirlineName == newAirline.AirlineName);

            if (results.Count > 0)
            {
                throw new AirlineAlreadyExistsException("Error: Airline name: " + newAirline.AirlineName + " is already exists!");
            }
            else
            {
                result = "Success: Airline " + newAirline.AirlineName + " Created!";
                return (newAirline, result);
            }
        }
    }
}
