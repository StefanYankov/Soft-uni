using System;

namespace GenericScale
{
    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T leftElement;
        private T rightElement;

        public EqualityScale(T leftElement, T rightElement)
        {
            this.leftElement = leftElement;
            this.rightElement = rightElement;
        }

        public bool AreEqual()
        {
            int value = this.leftElement.CompareTo(this.rightElement);

            bool result = false;

            if (value != 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}