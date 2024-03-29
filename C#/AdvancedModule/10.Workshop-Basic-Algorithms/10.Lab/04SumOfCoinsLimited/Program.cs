﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04SumOfCoinsLimited
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new int[] { 10, 10, 10, 5, 5, 2, 5, 1, 1, 1, 2 };

            coins = coins
                .OrderByDescending(c => c)
                .ToArray();

            int target = int.Parse(Console.ReadLine());
            int sum = 0;
            List<int> result = new List<int>(); // remove
            //Solution with a dictionary
            //Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < coins.Length; i++)
            {
                if (sum + coins[i] > target)
                {
                    continue;
                }

                /* if (!result.ContainsKey(coins[i]))
                 * {
                 *  result.Add(coins[i], 0);
                 *
                 */

                sum += coins[i];
                result.Add(coins[i]); //change to result[coins[i]]++;

                if (sum == target)
                {
                    break;
                }
            }

            if (target != sum)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item); //Console.WriteLine(String.Format("{1} x {0} ", item.Key, item.Value));
                }
            }
        }
    }
}