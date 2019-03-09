using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class FlightAlreadyExistsException : Exception
    {
        public FlightAlreadyExistsException()
        {

        }
        public FlightAlreadyExistsException(string message)
            :base(message)
        {

        }

        public FlightAlreadyExistsException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
