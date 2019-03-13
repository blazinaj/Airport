using System;

namespace Transport.Exceptions
{
    class InvalidCruisePortException : Exception
    {
        public InvalidCruisePortException()
        {

        }
        public InvalidCruisePortException(string message)
            : base(message)
        {

        }

        public InvalidCruisePortException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}