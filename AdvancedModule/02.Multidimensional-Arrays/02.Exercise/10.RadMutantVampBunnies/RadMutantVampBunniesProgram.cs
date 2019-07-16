using System;
using System.Collections.Generic;
using System.Linq;


namespace _10.RadMutantVampBunnies
{
    class RadMutantVampBunniesProgram
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            matrix[currentRow, currentCol] = '.';

            char[] commands = Console.ReadLine()
                .ToCharArray();

            Queue<char> queue = new Queue<char>(commands);

            int newPlayerRow = currentRow;
            int newPlayerCol = currentCol;

            while (queue.Count > 0)
            {
                switch (queue.Dequeue())
                {
                    case 'U':
                        newPlayerRow -= 1;
                        break;
                    case 'D':
                        newPlayerRow += 1;
                        break;
                    case 'L':
                        newPlayerCol -= 1;
                        break;
                    case 'R':
                        newPlayerCol += 1;
                        break;
                }

                matrix = MultyplyBunnies(matrix, rows, cols);

                if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                    && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
                {
                    currentRow = newPlayerRow;
                    currentCol = newPlayerCol;

                    if (matrix[currentRow, currentCol] == 'B')
                    {
                        PrintMatrix(matrix, rows, cols);
                        Console.WriteLine($"dead: {currentRow} {currentCol}");
                        return;
                    }
                }
                else
                {
                    PrintMatrix(matrix, rows, cols);
                    Console.WriteLine($"won: {currentRow} {currentCol}");
                    return;
                }

            }
        }
        public static char[,] MultyplyBunnies(char[,] matrix, int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < cols)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                        if (row + 1 < rows)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
        }
        public static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}