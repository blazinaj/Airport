using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Trips
{
    class Flight : Trip
    {
        public Flight(string airLine, string originAirPort, string destinationAirPort, int year, int month, int day, string tripID)
        {
            bool isDateValid;
            string dateResult;
            (isDateValid, dateResult) = GlobalFunctions.IsDateValid(year, month, day);

            if (!SystemManager.airportInformation.DoesLineExist(airLine))
            {
                throw new InvalidFlightException("Error: AirLine " + airLine + " does not exist!");
            }
            else if (!SystemManager.airportInformation.DoesPortExist(originAirPort))
            {
                throw new InvalidFlightException("Error: AirPort " + originAirPort + " does not exist!");
            }
            else if (!SystemManager.airportInformation.DoesPortExist(destinationAirPort))
            {
                throw new InvalidFlightException("Error: AirPort " + destinationAirPort + " does not exist!");
            }
            else if (originAirPort == destinationAirPort)
            {
                throw new InvalidFlightException("Error: Origin Airport (" + originAirPort + ") cannot be same as Destination Airport (" + destinationAirPort + ")!");
            }
            else if (SystemManager.airportInformation.DoesTripExist(tripID))
            {
                throw new InvalidFlightException("Error: Trip (" + tripID + ") already exists!");
            }
            else if (!isDateValid)
            {
                throw new InvalidFlightException(dateResult);
            }
            else
            {
                TripLine = SystemManager.airportInformation.LineList.Find(x=> x.Name == airLine);
                OriginPort = SystemManager.airportInformation.PortList.Find(x => x.Name == originAirPort);
                DestinationPorts.Add(SystemManager.airportInformation.PortList.Find(x => x.Name == destinationAirPort));
                Year = year;
                Month = month;
                Day = day;
                TripID = tripID;
            }
        }
    }
}
