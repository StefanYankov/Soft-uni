using System;
using System.Text.RegularExpressions;

namespace _7._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection matches = Regex.Matches(text, regex);

            foreach (Match date in matches)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");


            }

        }
    }
}
