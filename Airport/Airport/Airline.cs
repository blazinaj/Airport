using System;
using System.Collections.Generic;

namespace Airport
{
    public class Airline : IDisplaySystemDetails
    {
        private readonly string _airlineName;

        internal string AirlineName => _airlineName;
        internal List<Flight> FlightList { get; set; } = new List<Flight>();

        internal Airline(string airlineName)
        {
           _airlineName = airlineName;
        }

        internal string CreateFlight(string airlineName, string originAirport, string destinationAirport, int year, int month, int day, string id)
        {
            strint result;
            if (airlineName != AirlineName)
            {
                result = "An Error occured while creating a flight";
                Console.WriteLine(result);
                return result;
            }

            if (originAirport == destinationAirport)
            {
                result = "Error: You cannot have the same Origin (" + originAirport + ") and Destination (" + destinationAirport + ") Airports!";
                Console.WriteLine(result);
                return result;
            }

            if (year < 1928)
            {
                result = "Error: Airports Didn't Even exist in the year " + year + "!";
                Console.WriteLine(result);
                return result;
            }

            if (month < 1 || month > 12)
            {
                result = "Error: " + month + " is not a valid month!";
                Console.WriteLine(result);
                return result;
            }

            if (day < 1 || day > 31)
            {
                result = "Error: " + day + " is not a valid day!";
                Console.WriteLine(result);
                return result;
            }

            if (FlightList.FindAll(x => x.ID == id).Count > 0)
            {
                result = "Error: A Flight with " + id + "already exists!";
                Console.WriteLine(result);
                return result;
            }

            result = "Success: Flight " + id + " Created!";
            FlightList.Add(new Flight(airlineName, originAirport, destinationAirport, year, month, day, id));
            Console.WriteLine(result);
            return result;
        }

        public string DisplaySystemDetails()
        {
            string returnForUnitTests = "";
            foreach (var flight in FlightList)
            {
                returnForUnitTests += flight.ToString();
                Console.WriteLine(flight.ToString());
            }

            foreach (var flight in FlightList)
            {
                flight.DisplaySystemDetails();
            }

            return returnForUnitTests;
        }

        public override string ToString()
        {
            return "Airline: " + _airlineName;
        }
    }
}