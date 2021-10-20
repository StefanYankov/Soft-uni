namespace P11PartyReFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PartyReFilterModuleProgram
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split();

            var filters = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                var commands = input.Split(";");

                var command = commands[0].Split();
                var filter = commands[1];
                var parameter = commands[2];


                switch (command[0])
                {
                    case "Add": filters.Add($"{filter};{parameter}"); break;
                    case "Remove": filters.Remove($"{filter};{parameter}"); break;
                }
            }

            Func<string, string, bool> startsWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> endsWith = (x, y) => x.EndsWith(y);
            Func<string, string, bool> length = (x, y) => x.Length == int.Parse(y);
            Func<string, string, bool> contains = (x, y) => x.Contains(y);

            foreach (var item in filters)
            {
                var currentFilterInfo = item.Split(";");
                var currentFilter = currentFilterInfo[0];
                var currentParameter = currentFilterInfo[1];

                switch (currentFilter)
                {
                    case "Starts with": guests = guests.Where(x => !startsWith(x, currentParameter)).ToArray(); break;
                    case "Ends with": guests = guests.Where(x => !endsWith(x, currentParameter)).ToArray(); break;
                    case "Length": guests = guests.Where(x => !length(x, currentParameter)).ToArray(); break;
                    case "Contains": guests = guests.Where(x => !contains(x, currentParameter)).ToArray(); break;
                }
            }
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
