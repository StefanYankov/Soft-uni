using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class RecordUniqueNamesProgram
    {
        static void Main()
        {
            int nameCount = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < nameCount; i++)
            {
                string input = Console.ReadLine();

                names.Add(input);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
