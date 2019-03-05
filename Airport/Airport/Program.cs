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

            //Uncomment after debugging
            Console.ReadLine();

            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("FRONT");
            res.CreateAirline("FRONTIER"); //INVALID
            res.CreateAirline("FRONT"); //INVALID

            //Uncomment after debugging
            Console.ReadLine();

            res.CreateFlight("DELTA", "DEN", "LON", 2018, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEN", 2018, 8, 8, "567abc");
            res.CreateFlight("DEL", "DEN", "LON", 2018, 9, 8, "567"); //invalid airline
            res.CreateFlight("DELTA", "LON33", "DEN33", 2019, 5, 7, "123");//invalid airports
            res.CreateFlight("AMER", "DEN", "LON", 2010, 40, 100, "123abc");//invalid date

            //Uncomment after debugging
            Console.ReadLine();

            res.CreateSection("DELTA","123", 2, 2, SeatClass.economy);
            res.CreateSection("DELTA","123", 2, 3, SeatClass.first);
            res.CreateSection("DELTA","123", 2, 3, SeatClass.first);//Invalid
            res.CreateSection("SWSERTT","123", 5, 5, SeatClass.economy);//Invalid airline

            ////Uncomment after debugging
            //Console.ReadLine();

            //res.BookSeat("DELTA", "123", SeatClass.first, 1, 'A');
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'A');
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'B');
            //res.BookSeat("DELTA888", "123", SeatClass.business, 1, 'A'); //Invalid airline
            //res.BookSeat("DELTA", "123haha7", SeatClass.business, 1, 'A'); //Invalid flightId
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'A'); //already booked



            res.DisplaySystemDetails();

            //Uncomment after debugging
            Console.ReadLine();

            res.FindAvailableFlights("DEN", "LON");
        }
    }
}
