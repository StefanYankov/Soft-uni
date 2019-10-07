using System;

namespace CustomDataStructure
{
    class Program
    {
        static void Main()
        {
            //var list = new CustomList();
            //var list2 = new CustomList(50);

            //list.Add(7);
            //list.Add(12);
            //list.Add(23);

            //list.AddRange(new int[] { 7, 34, 56, 12, 89, 65, 34, 2 });
            //list.RemoveAt(3);
            ////list.InsertAt(1456, 2);
            //list.InsertAt(4, 8);
            //list.Swap(2, 8);

            CustomStack st = new CustomStack();

            st.Push(6);
            st.Push(8);
            st.Push(78);
            st.Push(3);
            var x = st.Pop();
            st.Push(777);
            st.Push(123);
            var y = st.Peek();

            st.ForEach(Console.WriteLine);

        }
    }
}
