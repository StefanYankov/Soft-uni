using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class PeriodicTableProgram
    {
        static void Main()
        {
            SortedSet<string> compounds = new SortedSet<string>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    compounds.Add(input[j]);
                }
            }

            foreach (var compound in compounds)
            {
                Console.Write(compound + " ");
            }
        }
    }
}
