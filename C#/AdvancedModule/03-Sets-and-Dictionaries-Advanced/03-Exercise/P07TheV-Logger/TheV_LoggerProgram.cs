namespace P07TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TheV_LoggerProgram
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("Statistics"))
                {
                    break;
                }

                string name = input[0];
                string command = input[1];
                string toFollow = string.Empty;
                bool isFollowing = command.Equals("followed");
                if (isFollowing)
                {
                    toFollow = input[2];
                    if (!vloggers.ContainsKey(toFollow) || !vloggers.ContainsKey(name))
                    {
                        continue;
                    }

                    if (name.Equals(toFollow))
                    {
                        continue;
                    }

                    vloggers[name]["following"].Add(toFollow);
                    vloggers[toFollow]["followers"].Add(name);

                }

                if (!vloggers.ContainsKey(name))
                {
                    vloggers.Add(name, new Dictionary<string, HashSet<string>>());
                    vloggers[name]["followers"] = new HashSet<string>();
                    vloggers[name]["following"] = new HashSet<string>();
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int counter = 1;
            foreach (var vlogger in vloggers.OrderByDescending(f => f.Value["followers"].Count).ThenBy(f => f.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
