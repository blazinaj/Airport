using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class AirportNameException : Exception
    {
        public AirportNameException()
        {

        }
        public AirportNameException(string message)
            :base(message)
        {

        }

        public AirportNameException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
