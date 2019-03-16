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
    }
}
