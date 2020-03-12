using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSAGE = "Mission already completed. You cannot finish it again.";
        public InvalidMissionCompletionException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {
        }
    }
}
