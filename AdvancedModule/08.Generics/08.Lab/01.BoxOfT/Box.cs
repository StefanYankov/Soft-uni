using System;
using System.Collections.Generic;
using System.Linq;


namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> BoxItems;

        public int Count
        {
            get { return BoxItems.Count; }
        }

        public Box()
        {
            BoxItems = new List<T>();
        }

        public void Add(T element)
        {
            BoxItems.Add(element);
        }

        public T Remove()
        {
            if (Count > 0)
            {
                T lastElement = BoxItems.Last();
                BoxItems.RemoveAt(Count-1);
                return lastElement;
            }

            throw new InvalidOperationException("You cannot remove an element from an empty collection.");
            
        }
    }
}
