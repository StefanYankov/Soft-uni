using System;

namespace P07Custom_Exception.Exceptions
{
    public class InvalidPersonNameException : Exception
    {
        private const string ExceptionMessage = "Special character or numeric value in a name of any of the students are not allowed.";

        public InvalidPersonNameException()
            : base(ExceptionMessage)
        {
        }

        public InvalidPersonNameException(string message)
            : base(message)
        {
        }

        public InvalidPersonNameException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
