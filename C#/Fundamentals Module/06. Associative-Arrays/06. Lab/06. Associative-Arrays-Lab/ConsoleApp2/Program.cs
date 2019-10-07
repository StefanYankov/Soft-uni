using System;
using System.Collections.Generic;

namespace _3._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }
                dict[word].Add(synonim);
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
