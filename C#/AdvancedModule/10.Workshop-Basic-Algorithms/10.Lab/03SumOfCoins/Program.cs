using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new int[] {10, 5, 1, 2};

            coins = coins
                .OrderByDescending(c => c)
                .ToArray();

            int target = int.Parse(Console.ReadLine());
            int current = 0;
            int sum = 0;
            List<int> result = new List<int>();

            while (sum < target)
            {
                if (sum + coins[current] > target)
                {
                    current++;
                }
                else
                {
                    sum += coins[current];
                    result.Add(coins[current]);
                }

                if (current == coins.Length)
                {
                    throw new Exception("No solution found!");
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
