namespace P02Problem
{
    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            string pattern = @"(\|)(?<name>[A-Z]{4,})(\|)(\:)(\#)(?<title>[A-Za-z]+\s{1}[A-Za-z]+)(\#)";
            for (int i = 1; i <= numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input,pattern);
                if (matches.Count == 0)
                {
                    Console.WriteLine("Access denied!");
                    continue;
                }

                foreach (Match match in matches)
                {
                    var bossName = match.Groups["name"].Value;
                    var title = match.Groups["title"].Value;
                    int lengthOfTheName = bossName.Length;
                    int lengthOfTheTitle = title.Length;
                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {lengthOfTheName}");
                    Console.WriteLine($">> Armor: {lengthOfTheTitle}");
                }
            }
        }
    }
}
