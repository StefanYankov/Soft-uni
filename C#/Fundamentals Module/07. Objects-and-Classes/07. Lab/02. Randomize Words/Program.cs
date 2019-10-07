using System;
using System.Collections.Generic;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var random = new Random();
            var shuffledWords = new List<string>();

            foreach (var word in words)
            {
                int newIndex = random.Next(0, shuffledWords.Count + 1);
                shuffledWords.Insert(newIndex, word);

            }



            foreach (var word in shuffledWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
