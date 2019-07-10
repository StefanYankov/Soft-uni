using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main()
        {
            var inputNumberArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var integerStack = new Stack<int>();


            foreach (var number in inputNumberArray)
            {
                integerStack.Push(number);
            }


            var command = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    integerStack.Push(int.Parse(command[1]));
                    integerStack.Push(int.Parse(command[2]));

                }
                else
                {
                    if (integerStack.Count > int.Parse(command[1]))
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            integerStack.Pop();
                        }
                    }
                }

                command = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Sum: {integerStack.Sum()}");

        }
    }
}
