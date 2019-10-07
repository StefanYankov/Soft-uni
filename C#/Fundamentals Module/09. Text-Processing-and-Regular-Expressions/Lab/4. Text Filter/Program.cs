using System;

namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsAsString = Console.ReadLine();
            var wordsToRemove = wordsAsString.Split(", ");
            string text = Console.ReadLine();

            foreach (var wordToRemove in wordsToRemove)
            {
                string newString = new string('*', wordToRemove.Length);
                text = text.Replace(wordToRemove, newString);
            }

            Console.WriteLine(text);
        }
    }
}
