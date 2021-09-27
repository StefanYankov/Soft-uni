namespace P04CitiesByContAndCountry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CitiesByContinentAndCountryProgram
    {
        public static void Main()
        {
            var nestedDict = new Dictionary<string, Dictionary<string, List<string>>>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!nestedDict.ContainsKey(continent))
                {
                    nestedDict.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!nestedDict[continent].ContainsKey(country))
                {
                    nestedDict[continent].Add(country, new List<string>());
                }

                nestedDict[continent][country].Add(city);
            }

            foreach (var continent in nestedDict)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
