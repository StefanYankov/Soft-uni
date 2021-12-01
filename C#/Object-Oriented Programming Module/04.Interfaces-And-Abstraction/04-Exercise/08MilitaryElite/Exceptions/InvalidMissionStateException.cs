using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string DefaultExceptionMessage = "Invalid mission state!";
        public InvalidMissionStateException()
            : base(DefaultExceptionMessage)
        {
        }

        public InvalidMissionStateException(string message)
            : base(message)
        {
        }
    }
}
