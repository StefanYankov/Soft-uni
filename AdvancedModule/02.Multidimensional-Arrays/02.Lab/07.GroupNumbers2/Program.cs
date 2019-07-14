using System;
using System.Linq;

namespace _07.GroupNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[] sizes = new int[3];
            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                sizes[remainder]++;
            }

            int[][] matrix = 
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offsets = new int[3];
            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                int index = offsets[remainder];
                matrix[remainder][index] = number;
                offsets[remainder]++;
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
