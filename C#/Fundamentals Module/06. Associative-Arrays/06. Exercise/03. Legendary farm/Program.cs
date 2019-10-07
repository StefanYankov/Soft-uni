using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_farm
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>()
            {
            {"shards", 0},
            {"fragments", 0},
            {"motes", 0}
            };

            var junkElements = new Dictionary<string, int>();

            while (true)
            {
                bool haveWiner = false;

                //3 Motes 5 stones 5 Shards
                var tokens = Console.ReadLine().ToLower().Split(" ").ToArray();
                //[3, motes, 5, stones, 5, shards]
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);

                    if (dict.ContainsKey(type))
                    {
                        dict[type] += quantity;

                    }
                    else
                    {
                        if (!junkElements.ContainsKey(type))
                        {
                            junkElements[type] = 0;
                        }
                        junkElements[type] += quantity;
                    }

                    if (dict["motes"] >= 250 || dict["shards"] >= 250 || dict["fragments"] >= 250)
                    {
                        dict[type] = dict[type] - 250;
                        if (type == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                        }
                        else if (type == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                        }
                        else if (type == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                        }

                        haveWiner = true;
                        break;

                    }
                }

                if (haveWiner)
                {
                    break;
                }
            }

            foreach (var kvp in dict.OrderByDescending(x =>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkElements.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


        }
    }
}

