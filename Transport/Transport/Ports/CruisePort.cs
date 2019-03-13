using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport
{
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class CruisePort : Port
    {
        public CruisePort(string name)
        {
            const int MAXIUMUM_NAME_LENGTH = 30;
            const int MINUMUM_NAME_LENGTH = 1;

            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidCruisePortException("Error: Cannot create CruisePort " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidCruisePortException("Error: Cannot create CruisePort " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
