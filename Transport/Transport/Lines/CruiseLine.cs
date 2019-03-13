using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Lines
{
    class CruiseLine : Line
    {
        const int MINUMUM_NAME_LENGTH = 1;
        const int MAXIUMUM_NAME_LENGTH = 15;

        public CruiseLine(string name)
        {
            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidCruiseLineException("Error: Cannot create CruiseLine " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidCruiseLineException("Error: Cannot create CruiseLine " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
