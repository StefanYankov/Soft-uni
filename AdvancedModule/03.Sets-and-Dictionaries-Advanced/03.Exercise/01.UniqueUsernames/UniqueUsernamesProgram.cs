using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class UniqueUsernamesProgram
    {
        static void Main()
        {
            int usernamesCount = int.Parse(Console.ReadLine());

            HashSet<string> uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                string username = Console.ReadLine();

                uniqueUsernames.Add(username);
            }

            foreach (var username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
