using System;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemManager res = new SystemManager();
            res.CreateAirport("DEN");
            res.CreateAirport("DFW");
            res.CreateAirport("LON");
            res.CreateAirport("DEN"); //INVALID
            res.CreateAirport("DENW"); //INVALID

            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("FRONT");
            res.CreateAirline("FRONTIER"); //INVALID
            res.CreateAirline("FRONT"); //INVALID

            res.CreateFlight("DELTA", "DEN", "LON", 2018, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEN", 2018, 8, 8, "567abc");
        }
    }
}
