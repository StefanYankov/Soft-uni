namespace P01UniqueUsernames
{
    using System;
    using System.Collections.Generic;
    public class UniqueUsernamesProgram
    {
        public static void Main()
        {
            int countOfNames = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < countOfNames; i++)
            {
                string name = Console.ReadLine();

                uniqueNames.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine,uniqueNames));
        }
    }
}
