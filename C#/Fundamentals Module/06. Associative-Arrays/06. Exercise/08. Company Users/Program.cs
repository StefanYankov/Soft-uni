using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(" -> ").ToArray();

            var dict = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new List<string>());
                }

                if (!dict[input[0]].Contains(input[1]))
                {
                    dict[input[0]].Add(input[1]);
                }
                input = Console.ReadLine().Split(" -> ").ToArray();
            }

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value.OrderByDescending(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }

        }
    }
}
