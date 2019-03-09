using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class AirportAlreadyExistsException : Exception
    {
        public AirportAlreadyExistsException()
        {

        }
        public AirportAlreadyExistsException(string message)
            :base(message)
        {

        }

        public AirportAlreadyExistsException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
