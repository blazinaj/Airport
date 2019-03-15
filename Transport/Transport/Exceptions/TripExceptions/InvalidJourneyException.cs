using System;

namespace Transport.Exceptions
{
    class InvalidJourneyException : Exception
    {
        public InvalidJourneyException()
        {

        }
        public InvalidJourneyException(string message)
            : base(message)
        {

        }

        public InvalidJourneyException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}