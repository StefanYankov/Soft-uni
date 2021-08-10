using System.Linq;

namespace P04StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            string starPattern = @"[starSTAR]{1}";
            string decryptPattern =
                @"@(?<planetName>[A-za-z]+)\d*[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<order>[AD])![^@\-!:>]*->(?<soldierCount>\d+)";
            int count = 0;

            List<string> listAttackedPlanets = new List<string>();
            List<string> listDestroyedPlanets = new List<string>();

            int numberOfMessages = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfMessages; i++)
            {
                string input = Console.ReadLine();

                var starMatches = Regex.Matches(input, starPattern);
                count = starMatches.Count;
                StringBuilder decryptedMessage = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    int currentCharASCII = input[j];
                    char charToAdd = (char)(currentCharASCII - count);
                    decryptedMessage.Append(charToAdd);
                }

                var decryptedString = Regex.Matches(decryptedMessage.ToString(), decryptPattern);

                foreach (Match decryptedMatch in decryptedString)
                {
                    var planetName = decryptedMatch.Groups["planetName"].Value;
                    var population = decryptedMatch.Groups["population"].Value;
                    var soldierCount = decryptedMatch.Groups["soldierCount"].Value;
                    var order = decryptedMatch.Groups["order"].Value;

                    if (order.Equals("A"))
                    {
                        listAttackedPlanets.Add($"-> {planetName}");
                    }
                    else
                    {
                        listDestroyedPlanets.Add($"-> {planetName}");
                    }

                }

            }

            Console.WriteLine($"Attacked planets: {listAttackedPlanets.Count}");
            if (listAttackedPlanets.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, listAttackedPlanets.OrderBy(x => x)));
            }


            Console.WriteLine($"Destroyed planets: {listDestroyedPlanets.Count}");
            if (listDestroyedPlanets.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, listDestroyedPlanets.OrderBy(x => x)));
            }
        }
    }
}
