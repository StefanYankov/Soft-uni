using System.Collections.Generic;

namespace P02Race
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, int> raceRepository = new Dictionary<string, int>();
            for (int i = 0; i < participants.Length; i++)
            {
                string currentName = participants[i];
                raceRepository[currentName] = 0;
            }

            string input = string.Empty;

            string namePattern = @"(?<character>[A-Za-z])";
            string distancePattern = @"(?<digits>[0-9]{1})";

            while (!(input = Console.ReadLine()).Equals("end of race"))
            {
                MatchCollection charName = Regex.Matches(input, namePattern);
                string name = String.Join("", charName);

                var distanceDigits = Regex.Matches(input, distancePattern);
                int distance = 0;
                foreach (Match digit in distanceDigits)
                {
                    distance += int.Parse(digit.Value);
                }

                if (raceRepository.ContainsKey(name))
                {
                    raceRepository[name] += distance;
                }

            }

            string[] placeArray = new[] { "1st", "2nd", "3rd" };
            int counter = 0;

            foreach (var participant in raceRepository.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"{placeArray[counter]} place: {participant.Key}");
                counter++;
            }
        }
    }
}
