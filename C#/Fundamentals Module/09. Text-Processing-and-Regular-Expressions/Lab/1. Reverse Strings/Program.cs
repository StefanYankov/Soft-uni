using System;
using System.Collections.Generic;

namespace _1.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputWord = Console.ReadLine();
            string reversedWord = String.Empty;
            var dict = new Dictionary<string, string>(); 

            while (inputWord != "end")
            {

                for (int i = inputWord.Length - 1; i >= 0; i--)
                {
                    reversedWord += inputWord[i];

                }
                dict.Add(inputWord, reversedWord);
                reversedWord = String.Empty;
                inputWord = Console.ReadLine();
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} = {kvp.Value}");
            }
        }
    }
}
