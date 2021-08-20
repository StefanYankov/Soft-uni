namespace P04FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FastFoodProgram
    {
        public static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersQuantity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(ordersQuantity);
            bool isCompleted = false;

            int biggestOrder = orders.Max();
            Console.WriteLine(biggestOrder);

            while (true)
            {
                if (orders.Count == 0)
                {
                    isCompleted = true;
                    break;
                }
                int currentOrder = orders.Peek();

                if ((foodQuantity - currentOrder) < 0)
                {
                    break;
                }

                foodQuantity -= currentOrder;
                orders.Dequeue();
            }

            if (isCompleted)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ",orders)}");
            }
        }
    }
}
