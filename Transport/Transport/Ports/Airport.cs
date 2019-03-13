using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport
{
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class AirPort : Port
    {
        const int MAXIUMUM_NAME_LENGTH = 5;
        const int MINUMUM_NAME_LENGTH = 1;

        public AirPort(string name)
        {
            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidAirPortException("Error: Cannot create AirPort " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidAirPortException("Error: Cannot create AirPort " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Contains(" "))
            {
                throw new InvalidAirPortException("Error: Cannot create AirPort " + name + ", name cannot contain spaces!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
