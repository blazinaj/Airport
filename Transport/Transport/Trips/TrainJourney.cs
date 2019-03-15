using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Trips
{
    class TrainJourney : Trip
    {
        public TrainJourney(string trainLine, string originTrainPort, string destinationTrainPort, int year, int month, int day, string tripID)
        {
            (bool isDateValid, string dateResult) = GlobalFunctions.IsDateValid(year, month, day);

            if (!SystemManager.airportInformation.DoesLineExist(trainLine))
            {
                throw new InvalidJourneyException("Error: TrainLine " + trainLine + " does not exist!");
            }
            else if (!SystemManager.airportInformation.DoesPortExist(originTrainPort))
            {
                throw new InvalidJourneyException("Error: TrainPort " + originTrainPort + " does not exist!");
            }
            else if (!SystemManager.airportInformation.DoesPortExist(destinationTrainPort))
            {
                throw new InvalidJourneyException("Error: TrainPort " + destinationTrainPort + " does not exist!");
            }
            else if (originTrainPort == destinationTrainPort)
            {
                throw new InvalidJourneyException("Error: Origin TrainPort (" + originTrainPort + ") cannot be same as Destination TrainPort (" + destinationTrainPort + ")!");
            }
            else if (SystemManager.airportInformation.DoesTripExist(tripID))
            {
                throw new InvalidJourneyException("Error: Trip (" + tripID + ") already exists!");
            }
            else if (!isDateValid)
            {
                throw new InvalidJourneyException(dateResult);
            }
            else
            {
                TripLine = SystemManager.trainInformation.LineList.Find(x => x.Name == trainLine);
                OriginPort = SystemManager.trainInformation.PortList.Find(x => x.Name == originTrainPort);
                DestinationPorts.Add(SystemManager.trainInformation.PortList.Find(x => x.Name == destinationTrainPort));
                Year = year;
                Month = month;
                Day = day;
                TripID = tripID;
            }
        }
    }
}
