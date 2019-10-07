using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            var dict = new Dictionary<string, int>();
            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(resource))
                {
                    dict[resource] = 0;
                }

                dict[resource] += quantity;

                resource = Console.ReadLine();
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
