using System;
using System.Collections.Generic;

namespace Airport
{
    public class Flight : IDisplaySystemDetails
    {
        private string AirlineName { get; set; }
        internal string OriginAirport { get; set; }
        internal string DestinationAirport { get; set; }
        private int Year { get; set; }
        private int Month { get; set; }
        private int Day { get; set; }
        internal string ID { get; set; }
        internal List<FlightSection> FlightSectionList { get; set; } = new List<FlightSection>();


        public Flight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            AirlineName = aname;
            OriginAirport = orig;
            DestinationAirport = dest;
            Year = year;
            Month = month;
            Day = day;
            ID = id;
        }

        internal void CreateFlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            FlightSectionList.Add(new FlightSection(air, flId, rows, cols, seatClass));
            Console.WriteLine("Success: Flight Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Created!");
        }

        public string DisplaySystemDetails()
        {
            string returnForUnitTests = "";
            foreach (var section in FlightSectionList)
            {
                returnForUnitTests += section.ToString();
                Console.WriteLine(section.ToString());
            }

            foreach (var section in FlightSectionList)
            {
                returnForUnitTests += section.ToString();
                section.DisplaySystemDetails();
            }

            return returnForUnitTests;
        }

        public override string ToString()
        {
            return "Flight Number: " + ID + " Airline Name: " + AirlineName + " Origin Airport: " + OriginAirport + " Destination Airport: " + DestinationAirport + " Date: " + Month+"/"+Day+"/"+Year;
        }
    }
}