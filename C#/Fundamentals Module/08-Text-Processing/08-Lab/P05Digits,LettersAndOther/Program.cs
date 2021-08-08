using System.Collections.Generic;

namespace P05Digits_LettersAndOther
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<char>> repository = new Dictionary<string, List<char>>
            {
                { "digits", new List<char>() },
                { "letters", new List<char>() },
                { "other", new List<char>() }
            };

            for (int i = 0; i < input.Length; i++)
            {
                char currentItem = input[i];

                if (Char.IsDigit(currentItem))
                {
                    repository["digits"].Add(currentItem);
                }
                else if (Char.IsLetter(currentItem))
                {
                    repository["letters"].Add(currentItem);
                }
                else
                {
                    repository["other"].Add(currentItem);
                }
            }

            Console.WriteLine(String.Join("", repository["digits"]));
            Console.WriteLine(String.Join("", repository["letters"]));
            Console.WriteLine(String.Join("", repository["other"]));
        }
    }
}
