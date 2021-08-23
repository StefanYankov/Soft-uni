namespace P02SumMatrixColumns
{
    using System;
    using System.Linq;
    public class SumMatrixColumnsProgram
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalSum = 0;
            int[,] matrix = new int[size[0], size[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int tempSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    tempSum += matrix[row, column];
                }
                Console.WriteLine(tempSum);
            }
        }
    }
}
