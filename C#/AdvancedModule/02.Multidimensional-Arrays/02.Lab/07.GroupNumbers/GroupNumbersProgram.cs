using System;
using System.Linq;

namespace _07.GroupNumbers
{
    class GroupNumbersProgram
    {
        static void Main()
        {
            int[][] matrix = new int[3][];

            int[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix[0] = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            matrix[1] = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            matrix[2] = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
