using System;
using System.Collections.Generic;
using System.Linq;

namespace P03P_rates
{
    public class P03Pirates
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> cities = new Dictionary<string, Dictionary<string, int>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] commandArgs = command.Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string city = commandArgs[0];
                int population = int.Parse(commandArgs[1]);
                int gold = int.Parse(commandArgs[2]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new Dictionary<string, int>
                    {
                        {"population", 0 },
                        {"gold", 0 }
                    });
                }

                cities[city]["population"] += population;
                cities[city]["gold"] += gold;

            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = commandArgs[0];
                string town = commandArgs[1];
                int people = 0;
                int gold = 0;
                switch (action)
                {
                    case "Plunder":
                        people = int.Parse(commandArgs[2]);
                        gold = int.Parse(commandArgs[3]);

                        cities[town]["population"] -= people;
                        cities[town]["gold"] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (cities[town]["population"] <= 0 || cities[town]["gold"] <= 0)
                        {

                            cities.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        gold = int.Parse(commandArgs[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            break;
                        }

                        cities[town]["gold"] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town]["gold"]} gold.");
                        break;
                }

            }

            if (cities.Count <= 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var kvp in cities
                .OrderByDescending(x => x.Value["gold"])
                .ThenBy(a => a.Key))
            {
                Console.WriteLine(
                    $"{kvp.Key} -> Population: {cities[kvp.Key]["population"]} citizens, Gold: {cities[kvp.Key]["gold"]} kg"
                    );
            }
        }
    }
}
