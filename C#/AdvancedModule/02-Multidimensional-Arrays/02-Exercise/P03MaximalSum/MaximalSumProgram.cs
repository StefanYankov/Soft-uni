namespace P03MaximalSum
{
    using System;
    using System.Linq;
    public class MaximalSumProgram
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] columns = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = columns[col];
                }
            }

            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                     + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                     + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }

            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
