namespace P01CountSameValuesInArray
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class CountSameValuesInArrayProgram
    {
        public static void Main()
        {
            double[] input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dictionary.ContainsKey(input[i]))
                {
                    dictionary[input[i]] = 0;
                }

                dictionary[input[i]]++;
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
