using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport
{
    public class SystemManager
    {
        public SystemFactory airFactory = new AirportFactory();
        public SystemFactory cruiseFactory = new AirportFactory();
        public SystemFactory trainFactory = new AirportFactory();
    }
}
