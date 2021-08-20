namespace P01BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BasicStackOperationsProgram
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int numberOfElementsToPush = input[0];
            int numberOfElementsToPop = input[1];
            int elementToFind = input[2];
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                stack.Pop();
            }

            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
