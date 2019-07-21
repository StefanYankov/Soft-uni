using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class SortEvenNumbersProgram
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(String.Join(", ", numbers
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)));
        }
    }
}
