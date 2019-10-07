using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numberArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNumbers = new Queue<int>();

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] % 2 == 0)
                {
                    evenNumbers.Enqueue(numberArray[i]);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
