namespace P02BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BasicQueueOperationsProgram
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int numberOfElementsToEnqueue = input[0];
            int numberOfElementsToDequeue = input[1];
            int elementToFind = input[2];
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numberOfElementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToDequeue; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                queue.Dequeue();
            }

            if (queue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
