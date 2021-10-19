namespace P04FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FindEvensOrOddsProgram
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            string numberType = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;
            Action<List<int>> printNumbers = outputNumbers 
                => Console.WriteLine(string.Join(" ", numbers));

            if (numberType == "odd")
            {
                numbers = numbers
                    .Where(x => isOdd(x))
                    .ToList();
            }
            else
            {
                numbers = numbers
                    .Where(x => isEven(x))
                    .ToList();
            }

            printNumbers(numbers);
        }
    }
}
