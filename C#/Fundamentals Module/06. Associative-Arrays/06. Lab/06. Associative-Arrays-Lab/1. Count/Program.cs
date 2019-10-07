using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersAsString = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var item in numbersAsString)
            {
                if (!counts.ContainsKey(item))
                {
                    counts[item] = 0;
                }
                counts[item]++;

            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
