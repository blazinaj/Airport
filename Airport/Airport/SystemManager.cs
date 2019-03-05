using System;
using System.Collections.Generic;

namespace Airport
{
    public class SystemManager
    {
        List<Airport> airportList = new List<Airport>();
        List<Airline> airlineList = new List<Airline>();

        public void CreateAirport(string n)
        {
            Airport newAirport = null;

            if (n.Length == 3)
            {
                newAirport = new Airport(n);
            }
            else
            {
                Console.WriteLine("Error: Could not create Airport, name: " + n + " must be exactly 3 letters!");
                return;
            }

            List<Airport> results = airportList.FindAll(x => newAirport != null && x.AirportName == newAirport.AirportName);

            if (results.Count > 0)
            {
                if (newAirport != null) Console.WriteLine("Error: Airport name: " + newAirport.AirportName + " already exists!");
                return;
            }
            else
            {
                airportList.Add(newAirport);
                Console.WriteLine("Success: Airport " + newAirport.AirportName + " Created!");
            }
        }

        public void CreateAirline(string n)
        {
            Airline newAirline = null;

            if (n.Length < 6)
            {
                newAirline = new Airline(n);
            }
            else
            {
                Console.WriteLine("Error: Airline name: " + n + " is longer than 5 letters!");
                return;
            }


            List<Airline> results = airlineList.FindAll(x => newAirline != null && x.AirlineName == newAirline.AirlineName);

            if (results.Count > 0)
            {
                Console.WriteLine("Error: Airline name: " + newAirline.AirlineName + " is already exists!");
                return;
            }
            else
            {
                airlineList.Add(newAirline);
                Console.WriteLine("Success: Airline " + newAirline.AirlineName + " Created!");
            }
            
        }

        public void CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            List<Airline> airlineResults = airlineList.FindAll(x => x.AirlineName == aname);
            List<Airport> airportOrigResults = airportList.FindAll(x => x.AirportName == orig);
            List<Airport> airportDestResults = airportList.FindAll(x => x.AirportName == dest);

            if (airlineResults.Count < 1)
            {
                Console.WriteLine("Error: Could not Create Flight, " + aname + " is not a valid airline!");
                return;
            }
            else if (airportOrigResults.Count < 1)
            {
                Console.WriteLine("Error: Could not Create Flight, " + orig + " is not a valid airport!");
                return;
            }
            else if (airportDestResults.Count < 1)
            {
                Console.WriteLine("Error: Could not Create Flight, " + dest + " is not a valid airport!");
                return;
            }
            else if (airlineResults.Count > 0 && airportOrigResults.Count > 0 && airportDestResults.Count > 0)
            {
                airlineResults.Find(x => x.AirlineName == aname).CreateFlight(aname, orig, dest, year, month, day, id);
            }
            else
            {
                Console.WriteLine("Some weird error happened");
            }
 
            
        }

        public void CreateSection(string air, string flID, int rows, int cols, SeatClass s)
        {
            if (airlineList.FindAll(x => x.AirlineName == air).Count < 1)
            {
                Console.WriteLine("Error: The Airline " + air + " Does Not Exist!");
                return;
            }

            if (rows > 100 || rows < 1)
            {
                Console.WriteLine("Error: You must have between 1 and 100 rows!");
                return;
            }

            if (cols > 10 || cols < 1)
            {
                Console.WriteLine("Error: You must have between 1 and 10 columns!");
                return;
            }

            if ((airlineList.Find(x => x.AirlineName == air).FlightList.FindAll(x => x.ID == flID).Count) < 1)
            {
                Console.WriteLine("Error: The Flight " + flID + " associated with the Airline " + air + " Does Not Exist!");
                return;
            }

            if ((airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).FlightSectionList.FindAll(x => x.seatClass == s)).Count > 0)
            {
                Console.WriteLine("Error: A flight section with Seat Class " + s + " already exists on Flight " + flID + " with " + air + " airline!");
                return;
            }

            airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).CreateFlightSection(air, flID, rows, cols, s);
        }

        public void BookSeat(string air, string fl, SeatClass s, int row, char col)
        {

        }

        public void DisplaySystemDetails()
        {

        }

        public void FindAvailableFlights(string den, string lon)
        {

        }
    }
}
