using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class SumMatrixColumnsProgram
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                   .Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] col = Console.ReadLine()
                    .Split()
                    .Select(int.Parse).
                    ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = col[c];
                }
            }
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int sum = 0;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    sum += matrix[r, c];
                }
                Console.WriteLine(sum);
            }

        }

    }
}
