using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructure
{
    public class CustomStack
    {
        /// <summary>
        /// Default size of the internal array
        /// </summary>
        private const int defaultSize = 4;

        /// <summary>
        /// Internal array
        /// </summary>
        private int[] innerArr;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        public CustomStack()
        {
            innerArr = new int[defaultSize];
        }

        public void Push(int element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }
            innerArr[Count] = element;
            Count++;
        }

        public int Peek()
        {
            CheckIfEmpty();
            return innerArr[Count - 1];
        }


        public int Pop()
        {
            CheckIfEmpty();
            Count--;
            int tempElement = innerArr[Count];
            innerArr[Count] = default;

            return tempElement;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(innerArr[i]);
            }
        }

        #region Private
        private void Grow()
        {
            int[] tempArr = new int[innerArr.Length * 2];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }
        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
        #endregion

    }
}
