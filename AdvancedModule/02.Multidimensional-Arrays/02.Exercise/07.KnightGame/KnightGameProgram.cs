using System;

namespace _07.KnightGame
{
    class KnightGameProgram
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                matrix[row] = input;
            }

            var counter = 0;
            var maxCounter = 0;
            var maxRow = -1;
            var maxCol = -1;
            var counterRemoved = 0;

            while (true)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            if (GetPosiition(matrix, row - 2, col - 1))
                            {
                                if (matrix[row - 2][col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row - 2, col + 1))
                            {
                                if (matrix[row - 2][col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row - 1, col + 2))
                            {
                                if (matrix[row - 1][col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row - 1, col - 2))
                            {
                                if (matrix[row - 1][col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row + 1, col - 2))
                            {
                                if (matrix[row + 1][col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row + 1, col + 2))
                            {
                                if (matrix[row + 1][col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row + 2, col - 1))
                            {
                                if (matrix[row + 2][col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (GetPosiition(matrix, row + 2, col + 1))
                            {
                                if (matrix[row + 2][col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }

                        }
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            maxRow = row;
                            maxCol = col;
                        }
                        counter = 0;
                    }
                }
                if (maxCounter != 0)
                {
                    counterRemoved++;
                    matrix[maxRow][maxCol] = '0';
                    maxCounter = 0;
                }
                else
                {
                    Console.WriteLine(counterRemoved);
                    return;
                }
            }
        }
        public static bool GetPosiition(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}