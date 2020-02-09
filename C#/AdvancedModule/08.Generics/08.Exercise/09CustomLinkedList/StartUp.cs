using System;

namespace _09CustomLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MyCustomLinkedList<int> customLinkedList = new MyCustomLinkedList<int>();
            customLinkedList.AddFirst(1);
            customLinkedList.AddFirst(2);
            customLinkedList.AddFirst(3);
            customLinkedList.AddFirst(4);
            customLinkedList.ForEach(Console.WriteLine);
        }
    }
}
