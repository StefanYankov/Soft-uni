using System;

namespace P04WildFarm.Utility.Exceptions
{
    public class DoesNotEatFoodException : Exception
    {
        public DoesNotEatFoodException(string message)
        : base(message)
        {
        }
    }
}
