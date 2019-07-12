using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FastFood
{
    class Program
    {
        static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> foodOrder = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int maxOrder = 0;

            Console.WriteLine(foodOrder.Max());
            if (foodQuantity >= foodOrder.Sum())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (foodQuantity > foodOrder.Peek())
                {
                    int number = foodOrder.Dequeue();
                    foodQuantity -= number;
                    
                    if (number > maxOrder)
                    {
                        maxOrder = number;
                    }
                }
                Console.WriteLine($"Orders left: {string.Join(" ", foodOrder)}");
            }
        }
    }
}
