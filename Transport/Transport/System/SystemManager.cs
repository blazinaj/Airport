using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport
{
    public static class SystemManager
    {
        public static SystemFactory airFactory = new AirportFactory();
        public static SystemFactory cruiseFactory = new CruiseFactory();
        public static SystemFactory trainFactory = new TrainFactory();

        public static SystemInformation airportInformation = new SystemInformation();
        public static SystemInformation cruiseInformation = new SystemInformation();
        public static SystemInformation trainInformation = new SystemInformation();
    }
}
