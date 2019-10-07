using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" | ");
            string[] words = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();

            //programmer: an animal, which turns coffee into code | developer: a magician
            for (int i = 0; i < input.Length; i++)
            {
                var arr = input[i].Split(": ").ToArray();
                string word = arr[0];
                string definition = arr[1];

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, new List<string> { definition });
                }
                else
                {
                    dict[word].Add(definition);
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    Console.WriteLine(words[i]);
                    foreach (var definition in dict[words[i]].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            if (command == "List")
            {
                List<string> listOfWords = new List<string>();
                foreach (var word in dict.OrderBy(x => x.Key))
                {
                    listOfWords.Add(word.Key);
                }
                Console.WriteLine(string.Join(" ", listOfWords));
            }
            //foreach (var kvp in dict)
            //{
            //    Console.WriteLine(kvp.Key);
            //    for (int i = 0; i < kvp.Value.Count; i++)
            //    {
            //        Console.WriteLine($"- {kvp.Value[i]}");
            //    }
            //}

        }
    }
}
