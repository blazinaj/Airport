using System;

namespace Transport.Exceptions
{
    class InvalidTrainLineException : Exception
    {
        public InvalidTrainLineException()
        {

        }
        public InvalidTrainLineException(string message)
            : base(message)
        {

        }

        public InvalidTrainLineException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}