namespace P02MirrorWords
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var pattern = @"(\@|#{1})(?<word>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();
            List<string> pairs = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                var firstWord = match.Groups["word"].Value;
                var secondWord = match.Groups["secondWord"].Value;
                var reversedSecondWord = Reverse(secondWord);
                if (firstWord.Equals(reversedSecondWord))
                {
                    pairs.Add($"{firstWord} <=> {secondWord}");
                }

            }

            int count = matches.Count;
            if (count == 0)
            {
                Console.WriteLine($"No word pairs found!{Environment.NewLine}No mirror words!");
            }
            else if (pairs.Count == 0)
            {
                Console.WriteLine($"{count} word pairs found!{Environment.NewLine}No mirror words!");
            }
            else
            {
                Console.WriteLine($"{count} word pairs found!");
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", pairs));
            }


        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
