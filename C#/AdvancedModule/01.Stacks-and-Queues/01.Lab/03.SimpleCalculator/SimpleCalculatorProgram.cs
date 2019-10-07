using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries) // 2 + 5 + 10 - 2 - 1
                .ToArray();

            Stack<int> result = new Stack<int>(); 
            result.Push(int.Parse(input[0]));

            for (int i = 2; i < input.Length; i+=2)
            {
                if ((input[i - 1]).ToString() == "+")
                {
                    result.Push(int.Parse(input[i]));
                }
                else
                {
                    int currentValue = result.Sum() - int.Parse(input[i]);
                    result.Clear();
                    result.Push(currentValue);
                }

            }

            Console.WriteLine(result.Sum());

        }
    }
}
