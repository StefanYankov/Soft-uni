using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class TheVLoggerProgram
    {
        public static void Main()
        {
            var vloggerAndFollowers = new Dictionary<string, List<string>>();
            var vloggerAndFollowing = new Dictionary<string, int[]>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }
                var info = input.Split();
                var name = info[0];

                if (input.Contains("joined"))
                {
                    if (!vloggerAndFollowers.ContainsKey(name))
                    {
                        vloggerAndFollowers.Add(name, new List<string>());
                        vloggerAndFollowing.Add(name, new int[2]);
                    }
                }
                else if (input.Contains("followed"))
                {
                    var followedName = info[2];
                    if (vloggerAndFollowers.ContainsKey(name) && vloggerAndFollowers.ContainsKey(followedName)
                        && name != followedName && !vloggerAndFollowers[followedName].Contains(name))
                    {
                        vloggerAndFollowers[followedName].Add(name);
                        vloggerAndFollowing[followedName][0]++;
                        vloggerAndFollowing[name][1]++;
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of { vloggerAndFollowers.Count} vloggers in its logs.");

            var counter = 1;

            foreach (var item in vloggerAndFollowing.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]))
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");

                if (counter == 1)
                {
                    var topFollowed = vloggerAndFollowers.First(x => x.Key == item.Key);

                    foreach (var first in topFollowed.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {first}");
                    }
                }
                counter++;
            }
        }
    }
}
