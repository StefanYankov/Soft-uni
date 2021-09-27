namespace P05RecordUniqueNames
{
    using System;
    using System.Collections.Generic;
    public class RecordUniqueNamesProgram
    {
        public static void Main()
        {
            int countOfnames = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < countOfnames; i++)
            {
                string name = Console.ReadLine();
                set.Add(name);
            }
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
