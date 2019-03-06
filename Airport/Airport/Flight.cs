using System;
using System.Collections.Generic;

namespace Airport
{
    public class Flight : IDisplaySystemDetails
    {
        private string AirlineName { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
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

        public Flight()
        {
        }

        public void CreateFlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            FlightSectionList.Add(new FlightSection(air, flId, rows, cols, seatClass));
            Console.WriteLine("Success: Flight Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Created!");
        }

        public void DisplaySystemDetails()
        {
            foreach (var section in FlightSectionList)
            {
                Console.WriteLine(section.ToString());
            }

            foreach (var section in FlightSectionList)
            {
                section.DisplaySystemDetails();
            }

        }

        public override string ToString()
        {
            return "Flight Number: " + ID + " Airline Name: " + AirlineName + " Origin Airport: " + OriginAirport + " Destination Airport: " + DestinationAirport + " Date: " + Month+"/"+Day+"/"+Year;
        }
    }
}