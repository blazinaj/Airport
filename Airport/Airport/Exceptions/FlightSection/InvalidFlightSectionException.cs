using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class InvalidFlightSectionException : Exception
    {
        public InvalidFlightSectionException()
        {

        }
        public InvalidFlightSectionException(string message)
            : base(message)
        {

        }

        public InvalidFlightSectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
