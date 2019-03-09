using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class AirlineAlreadyExistsException : Exception
    {
        public AirlineAlreadyExistsException()
        {

        }
        public AirlineAlreadyExistsException(string message)
            :base(message)
        {

        }

        public AirlineAlreadyExistsException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
