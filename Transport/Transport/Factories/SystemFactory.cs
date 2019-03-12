using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// The AbstractFactory class, which defines methods for creating abstract objects.
    /// </summary>
    public abstract class SystemFactory
    {
        public abstract Port CreatePort(string name);
        public abstract Line CreateLine();
        public abstract Trip CreateTrip();
    }
}
