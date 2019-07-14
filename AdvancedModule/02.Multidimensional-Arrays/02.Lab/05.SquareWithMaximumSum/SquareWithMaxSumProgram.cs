﻿using System;
using System.Linq;


namespace _05.SquareWithMaximumSum
{
    class SquareWithMaxSumProgram
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] columns = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = columns[col];
                }
            }

            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }

            }

            for (int row = rowIndex; row < rowIndex + 2; row++)
            {
                for (int col = colIndex; col < colIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

        }
    }
}
