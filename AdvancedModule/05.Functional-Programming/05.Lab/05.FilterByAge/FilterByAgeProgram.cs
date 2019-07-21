using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class FilterByAgeProgram
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            var data = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = input[0];
                var age = int.Parse(input[1]);

                data.Add(new KeyValuePair<string, int>(name, age));
            }

            var condition = Console.ReadLine();
            var years = int.Parse(Console.ReadLine());
            var printFormat = Console.ReadLine().Split();

            data.Where(d => condition == "younger" ? d.Value < years : d.Value >= years)
                .ToList()
                .ForEach(d => Print(d, printFormat));
        }

        static void Print(KeyValuePair<string, int> person, string[] printFormat)
        {
            if (printFormat.Length == 2)
            {
                Console.WriteLine($"{person.Key} - {person.Value}");
            }
            else
            {
                Console.WriteLine(printFormat[0] == "name" ? $"{person.Key}" : $"{person.Value}");
            }
        }
    }
}