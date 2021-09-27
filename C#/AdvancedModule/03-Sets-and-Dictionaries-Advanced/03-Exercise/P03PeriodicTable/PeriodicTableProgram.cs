namespace P03PeriodicTable
{
    using System;
    using System.Collections.Generic;
    public class PeriodicTableProgram
    {
        public static void Main()
        {
            int countOfChemicalCompounds = int.Parse(Console.ReadLine());
            SortedSet<string> periodicTable = new SortedSet<string>();
            for (int i = 0; i < countOfChemicalCompounds; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in chemicalCompounds)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ',periodicTable));
        }
    }
}
