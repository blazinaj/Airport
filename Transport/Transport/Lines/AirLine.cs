using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Lines
{
    class AirLine : Line
    {
        const int MINUMUM_NAME_LENGTH = 1;
        const int MAXIUMUM_NAME_LENGTH = 5;
        public AirLine(string name)
        {
            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidAirlineException("Error: Cannot create AirLine " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidAirlineException("Error: Cannot create AirLine " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Contains(" "))
            {
                throw new InvalidAirlineException("Error: Cannot create AirLine " + name + ", name cannot contain spaces!");
            }
            else
            {
                Name = name;
            }
        }

    }
}
