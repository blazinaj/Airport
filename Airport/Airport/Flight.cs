using System;
using System.Collections.Generic;

namespace Airport
{
    public class Flight
    {
        private string AirlineName { get; set; }
        private string OriginAirport { get; set; }
        private string DestinationAirport { get; set; }
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

        public void CreateFlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            FlightSectionList.Add(new FlightSection(air, flId, rows, cols, seatClass));
            Console.WriteLine("Success: Flight Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Created!");
        }
    }
}