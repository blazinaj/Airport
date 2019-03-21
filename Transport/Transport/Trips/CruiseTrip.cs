using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Trips
{
    class CruiseTrip : Trip
    {
        public CruiseTrip(string cruiseLine, string originCruisePort, string destinationCruisePort, int year, int month, int day, int hour, int minutes, string tripID)
        {
            (bool isDateValid, string dateResult) = GlobalFunctions.IsDateValid(year, month, day);

            if (!SystemManager.cruiseInformation.DoesLineExist(cruiseLine))
            {
                throw new InvalidCruiseException("Error: CruiseLine " + cruiseLine + " does not exist!");
            }
            else if (!SystemManager.cruiseInformation.DoesPortExist(originCruisePort))
            {
                throw new InvalidCruiseException("Error: CruisePort " + originCruisePort + " does not exist!");
            }
            else if (!SystemManager.cruiseInformation.DoesPortExist(destinationCruisePort))
            {
                throw new InvalidCruiseException("Error: CruisePort " + destinationCruisePort + " does not exist!");
            }
            else if (originCruisePort == destinationCruisePort)
            {
                throw new InvalidCruiseException("Error: Origin CruisePort (" + originCruisePort + ") cannot be same as Destination CruisePort (" + destinationCruisePort + ")!");
            }
            else if (SystemManager.cruiseInformation.DoesTripExist(tripID))
            {
                throw new InvalidCruiseException("Error: Trip (" + tripID + ") already exists!");
            }
            else if (!isDateValid)
            {
                throw new InvalidCruiseException(dateResult);
            }
            else
            {
                TripLine = SystemManager.cruiseInformation.LineList.Find(x => x.Name == cruiseLine);
                OriginPort = SystemManager.cruiseInformation.PortList.Find(x => x.Name == originCruisePort);
                DestinationPort = SystemManager.cruiseInformation.PortList.Find(x => x.Name == destinationCruisePort);
                DestinationPorts.Add(SystemManager.cruiseInformation.PortList.Find(x => x.Name == destinationCruisePort));
                Year = year;
                Month = month;
                Day = day;
                TripID = tripID;
                Hour = hour;
                Minutes = minutes;
            }
        }
    }
}
