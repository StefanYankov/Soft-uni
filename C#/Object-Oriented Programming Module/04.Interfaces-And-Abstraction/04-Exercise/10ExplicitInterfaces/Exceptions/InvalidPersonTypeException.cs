using System;

namespace ExplicitInterfaces.Exceptions
{
    public class InvalidPersonTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid person type!";

        public InvalidPersonTypeException()
        {

        }

        public InvalidPersonTypeException(string message)
            : base(EXCEPTION_MESSAGE)
        {

        }
    }
}