using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" : ").ToArray();

            var courses = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                if (!courses.ContainsKey(input[0]))
                {
                    courses.Add(input[0], new List<string>());
                }
                courses[input[0]].Add(input[1]);

                input = Console.ReadLine().Split(" : ").ToArray();

            }

            foreach (var kvp in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var name in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {string.Join("", name)}");

                }
            }
        }
    }
}
