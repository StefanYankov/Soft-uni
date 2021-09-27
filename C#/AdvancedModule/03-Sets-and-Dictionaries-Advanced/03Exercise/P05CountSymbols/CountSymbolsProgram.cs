namespace P05CountSymbols
{
    using System;
    using System.Collections.Generic;
    public class CountSymbolsProgram
    {
        public static void Main()
        {
            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var @char in input)
            {
                if (!countSymbols.ContainsKey(@char))
                {
                    countSymbols.Add(@char,0);
                }

                countSymbols[@char]++;
            }

            foreach (var kvp in countSymbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
