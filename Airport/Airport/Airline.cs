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

        internal void CreateFlight(string airlineName, string originAirport, string destinationAirport, int year, int month, int day, string id)
        {
            if (airlineName != AirlineName)
            {
                Console.WriteLine("An Error occured while creating a flight");
                return;
            }

            if (originAirport == destinationAirport)
            {
                Console.WriteLine("Error: You cannot have the same Origin (" + originAirport + ") and Destination (" + destinationAirport + ") Airports!");
                return;
            }

            if (year < 1928)
            {
                Console.WriteLine("Error: Airports Didn't Even exist in the year " + year + "!");
                return;
            }

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Error: " + month + " is not a valid month!");
                return;
            }

            if (day < 1 || day > 31)
            {
                Console.WriteLine("Error: " + day + " is not a valid day!");
                return;
            }

            if (FlightList.FindAll(x => x.ID == id).Count > 0)
            {
                Console.WriteLine("Error: A Flight with " + id + "already exists!");
                return;
            }

            FlightList.Add(new Flight(airlineName, originAirport, destinationAirport, year, month, day, id));

            Console.WriteLine("Success: Flight " + id + " Created!");
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