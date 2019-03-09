using Airport.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Factories
{
    class FlightSectionFactory
    {
        const int MIN_COLS = 1;
        const int MAX_COLS = 10;
        const int MIN_ROWS = 1;
        const int MAX_ROWS = 100;
        public string CreateSection(string air, string flID, int rows, int cols, SeatClass s, List<Airline> airlineList)
        {
            string result;
            // Airline does not exist
            if (airlineList.FindAll(x => x.AirlineName == air).Count < 1)
            {
                throw new InvalidFlightSectionException("Error: The Airline " + air + " Does Not Exist!");
            }
            // Invalid Rows
            if (rows > MAX_ROWS || rows < MIN_ROWS)
            {
                throw new InvalidFlightSectionException("Error: You must have between " + MIN_ROWS + " and " + MAX_ROWS + " rows!");
            }
            // Invalid Cols
            if (cols > MAX_COLS || cols < MIN_COLS)
            {
                throw new InvalidFlightSectionException("Error: You must have between " + MIN_COLS + " and " + MAX_COLS + " columns!");
            }
            // Invalid Flight ID
            if ((airlineList.Find(x => x.AirlineName == air).FlightList.FindAll(x => x.ID == flID).Count) < 1)
            {
                throw new InvalidFlightSectionException("Error: The Flight " + flID + " associated with the Airline " + air + " Does Not Exist!");
            }
            // Invalid SeatClass
            if ((airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).FlightSectionList.FindAll(x => x.seatClass == s)).Count > 0)
            {
                throw new InvalidFlightSectionException("Error: A flight section with Seat Class " + s + " already exists on Flight " + flID + " with " + air + " airline!");
            }

            try
            {
                result = airlineList.Find(x => x.AirlineName == air).FlightList.Find(x => x.ID == flID).CreateFlightSection(air, flID, rows, cols, s);
            } catch (InvalidFlightSectionException e)
            {
                throw new InvalidFlightSectionException(e.Message);
            }
            return result;
        }
    }
}
