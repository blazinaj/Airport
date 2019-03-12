using Airport.Exceptions;
using System;
using System.Collections.Generic;

namespace Airport
{
    internal class Factory
    {
        const int REQUIRED_AIRPORT_NAME_LENGTH = 3;

        internal (Port port, string success) CreatePort(string type, string name, List<Port> portList)
        {
            if (type != "airport" && type != "cruiseport" && type != "trainport")
            {
                throw new TypeNotFoundException("Error: " + type + " is not a valid type!");
            }
            else
            {
                List<Port> results = portList.FindAll(x => x.Name == name);

                if (results.Count > 0)
                {
                    throw new PortException("Error: " + type + " name " + name + " already exists!");
                }
                else if (name.Length != REQUIRED_AIRPORT_NAME_LENGTH)
                {
                    throw new PortException("Error: Could not create " + type + ", name: " + name + " must be exactly 3 letters!");
                }
                else if (name.Contains(" "))
                {
                    throw new PortException("Error: Could not create " + type + ", name: " + name + " cannot contain spaces!");
                }
                else
                {

                    Port newPort = new Port(type, name);
                    string success = "Success: " + newPort.Type + " " + newPort.Name + " Created!";

                    return (newPort, success);
                }
            }
        }

        internal static (Line line, string success) CreateLine(string type, string name)
        {
            throw new NotImplementedException();
        }
    }
}