using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            var reversingStack = new Stack<char>();

            foreach (var item in input)
            {
                reversingStack.Push(item);
            }


            while (reversingStack.Count > 0)
            {
                Console.Write(reversingStack.Peek());
                reversingStack.Pop();
            }
            Console.WriteLine();
        }
    }
}
