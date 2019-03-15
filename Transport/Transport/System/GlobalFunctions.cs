using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Transport
{
    public static class GlobalFunctions
    {
        public static (bool, string) IsDateValid(int year, int month, int day)
        {
            if (year < DateTime.Today.Year)
            {
                return (false, "Error: Year: " + year + " is invalid!");
            }
            else if (month < 1 || month > 12)
            {
                return (false, "Error: Month: " + month + " is invalid!");
            }
            else if (day < 1 || day > 31)
            {
                return (false, "Error: Day: " + day + " is invalid!");
            }
            else
            {
                return (true, "Success! Date is valid");
            }
        }

        public static string BookSeat(string line, string tripId, SeatClass s, int row, char col)
        {
            string result;
            SystemInformation systemInformation = new SystemInformation();
            systemInformation.BookedSeatsList.Where(x => (x.ColumnCharacter == col) && (x.RowNumber == row) && (x.IsBooked == false)).ToList().ForEach(x => x.IsBooked = true);
            result = "Success: Seat (" + col + row + ") with Seat Class " + s + " on Flight " + tripId + " with " + line + " airline " + " Booked!";
            Console.WriteLine(result);
            return result;
        }

    }
}
