using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Where(x => x != ' ').ToArray();
            var dict = new Dictionary<char, int>();

            foreach (var item in input)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 0;
                }
                dict[item]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
