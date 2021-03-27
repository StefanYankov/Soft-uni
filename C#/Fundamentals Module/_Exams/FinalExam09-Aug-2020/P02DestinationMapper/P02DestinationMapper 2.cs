using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02DestinationMapper
{
    public class P02DestinationMapper
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int travelPoints = 0;
            List<string> destinations = new List<string>();
            //=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=

            var matches = Regex.Matches(input, @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1");
            foreach (Match match in matches)
            {
                string tempMatch = match.ToString();
                int length = tempMatch.Length;
                destinations.Add(tempMatch.Substring(1, length - 2));
            }

            foreach (var destination in destinations)
            {
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {String.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}