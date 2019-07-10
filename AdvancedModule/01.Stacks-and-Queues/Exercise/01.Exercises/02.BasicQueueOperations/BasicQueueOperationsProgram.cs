using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(input[2]))
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
