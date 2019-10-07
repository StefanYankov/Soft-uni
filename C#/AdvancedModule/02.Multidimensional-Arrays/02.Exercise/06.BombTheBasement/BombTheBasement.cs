using System;
using System.Linq;

namespace _06.BombTheBasement
{
    class BombTheBasementProgram
    {
        static void Main()
        {
            int[] matrixSize = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bomb = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new int[rows, cols];
            var bombRow = bomb[0];
            var bombCol = bomb[1];
            var bombRadius = bomb[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var distance = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));

                    if (distance <= bombRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            var tempMatrix = new int[cols][];

            for (int row = 0; row < cols; row++)
            {
                tempMatrix[row] = new int[rows];

                for (int col = 0; col < rows; col++)
                {
                    tempMatrix[row][col] = matrix[col, row];
                }

                tempMatrix[row] = tempMatrix[row]
                    .OrderByDescending(x => x)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = tempMatrix[col][row];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}