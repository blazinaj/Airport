using System;
using System.Collections.Generic;
using System.Text;
using Transport.Lines;
using Transport.Trips;

namespace Transport.Factories
{
    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    public class AirportFactory : SystemFactory
    {
        public override Port CreatePort(string name)
        {
            return new AirPort(name);
        }
        public override Line CreateLine()
        {
            return new AirLine();
        }

        public override Trip CreateTrip()
        {
            return new AirTrip();
        }
    }
}
