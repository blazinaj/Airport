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
        private string ID { get; set; }

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
    }
}