namespace P02MatchPhoneNumber
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            string pattern = @"( ?\+359 2 [0-9]{3} [0-9]{4}\b)|( ?\+359-2-[0-9]{3}-[0-9]{4}\b)";
            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, pattern);

            string[] phoneMatchesArr = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(String.Join(", ", phoneMatchesArr));
        }
    }
}
