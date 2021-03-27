using System;
using System.Collections.Generic;
using System.Linq;

namespace P03PlantDiscovery
{
    public class P03PlantDiscovery
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, double>> plants = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();


            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int rarity = int.Parse(input[1]);

                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, new Dictionary<string, double>
                    {
                        {"rarity", 0},
                        {"averageRating", 0}
                    });

                    plants[name]["rarity"] += rarity;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = command.Split(new string[] { " - ", ": " }, StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[1];
                if (cmdArgs[0] == "Rate")
                {
                    int rating = int.Parse(cmdArgs[2]);
                    if (plants.ContainsKey(name) && rating >= 0)
                    {
                        if (ratings.ContainsKey(name))
                        {
                            ratings[name].Add(rating);
                        }
                        else
                        {
                            ratings.Add(name, new List<int> { rating });
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs[0] == "Update")
                {
                    int newRarity = int.Parse(cmdArgs[2]);
                    if (plants.ContainsKey(name) && newRarity >= 0)
                    {
                        plants[name]["rarity"] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs[0] == "Reset")
                {
                    if (plants.ContainsKey(name))
                    {
                        if (ratings.ContainsKey(name))
                        {
                            ratings[name].Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            foreach (var item in ratings)
            {
                double sum = 0;
                for (int i = 0; i < item.Value.Count; i++)
                {
                    sum += item.Value[i];
                }

                double average;
                if (sum > 0)
                {
                    average = sum / item.Value.Count;
                }
                else
                {
                    average = 0;
                }

                plants[item.Key]["averageRating"] = average;
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var currPlant in plants
                .OrderByDescending(x => x.Value["rarity"])
                .ThenByDescending(a => a.Value["averageRating"]))
            {
                Console.WriteLine($"- {currPlant.Key}; Rarity: {currPlant.Value["rarity"]}; Rating: {currPlant.Value["averageRating"]:f2}");
            }
        }
    }
}