using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            var wordArray = input.Split().ToArray();

            var dict = new Dictionary<string, int>();

            foreach (var element in wordArray)
            {
                if (!dict.ContainsKey(element))
                {
                    dict[element] = 0;
                }
                dict[element]++;
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");

                }
            }
            Console.WriteLine();
        }
    }
}
