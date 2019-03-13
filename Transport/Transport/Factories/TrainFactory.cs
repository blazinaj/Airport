using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;
using Transport.Lines;
using Transport.Trips;

namespace Transport.Factories
{
    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    public class TrainFactory : SystemFactory
    {
        public override (Port, string) CreatePort(string name)
        {
            try
            {
                Port newTrainPort = new TrainPort(name);
                string success = "Success: TrainPort " + newTrainPort.Name + " Successfully Created!";
                return (newTrainPort, success);
            }
            catch (InvalidTrainPortException e)
            {
                return (null, e.Message);
            }
        }
        public override (Line, string) CreateLine(string name)
        {
            try
            {
                Line newTrainLine = new TrainLine(name);
                string success = "Success: TrainLine " + newTrainLine.Name + " Successfully Created!";
                return (newTrainLine, success);
            }
            catch (InvalidTrainLineException e)
            {
                return (null, e.Message);
            }
        }

        public override Trip CreateTrip(string name)
        {
            return new TrainTrip(name);
        }
    }
}
