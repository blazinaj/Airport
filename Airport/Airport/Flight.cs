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

        internal string CreateFlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            string result;
            FlightSectionList.Add(new FlightSection(air, flId, rows, cols, seatClass));
            result = "Success: Flight Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Created!";
            Console.WriteLine(result);
            return result;
        }

        public string DisplaySystemDetails()
        {
            string result = "";
            result = ToString();
            Console.WriteLine(result);
            foreach (var section in FlightSectionList)
            {
                section.DisplaySystemDetails();
            }

            return result;
        }

        public override string ToString()
        {
            return "Flight Number: " + ID + " Airline Name: " + AirlineName + " Origin Airport: " + OriginAirport + " Destination Airport: " + DestinationAirport + " Date: " + Month+"/"+Day+"/"+Year;
        }
    }
}