using System;

namespace Workshop  
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddLast("Pesho");
            doublyLinkedList.AddLast("Gosho");
            doublyLinkedList.AddLast("Kiro");

            doublyLinkedList.Print(Console.WriteLine);
            string[] array = doublyLinkedList.ToArray();

            Console.WriteLine(doublyLinkedList.Contains("Gosho"));

            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
