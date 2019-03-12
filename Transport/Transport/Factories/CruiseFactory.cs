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
    public class CruiseFactory : SystemFactory
    {
        public override Port CreatePort(string name)
        {
            return new CruisePort(name);
        }
        public override Line CreateLine()
        {
            return new CruiseLine();
        }

        public override Trip CreateTrip()
        {
            return new CruiseTrip();
        }
    }
}
