using System;
using System.Linq;

namespace _08.Bombs
{
    class BombProgram
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[input.Length];
                matrix[row] = input;
            }

            string[] bombs = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] bomb = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int bombRow = bomb[0];
                int bombCol = bomb[1];

                if (GetPosiition(matrix, bombRow, bombCol))
                {
                    if (matrix[bombRow][bombCol] > 0)
                    {
                        if (GetPosiition(matrix, bombRow - 1, bombCol - 1))
                        {
                            if (matrix[bombRow - 1][bombCol - 1] > 0)
                            {
                                matrix[bombRow - 1][bombCol - 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow - 1, bombCol))
                        {
                            if (matrix[bombRow - 1][bombCol] > 0)
                            {
                                matrix[bombRow - 1][bombCol] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow - 1, bombCol + 1))
                        {
                            if (matrix[bombRow - 1][bombCol + 1] > 0)
                            {
                                matrix[bombRow - 1][bombCol + 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow, bombCol - 1))
                        {
                            if (matrix[bombRow][bombCol - 1] > 0)
                            {
                                matrix[bombRow][bombCol - 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow, bombCol + 1))
                        {
                            if (matrix[bombRow][bombCol + 1] > 0)
                            {
                                matrix[bombRow][bombCol + 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow + 1, bombCol - 1))
                        {
                            if (matrix[bombRow + 1][bombCol - 1] > 0)
                            {
                                matrix[bombRow + 1][bombCol - 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow + 1, bombCol))
                        {
                            if (matrix[bombRow + 1][bombCol] > 0)
                            {
                                matrix[bombRow + 1][bombCol] -= matrix[bombRow][bombCol];
                            }
                        }
                        if (GetPosiition(matrix, bombRow + 1, bombCol + 1))
                        {
                            if (matrix[bombRow + 1][bombCol + 1] > 0)
                            {
                                matrix[bombRow + 1][bombCol + 1] -= matrix[bombRow][bombCol];
                            }
                        }
                        matrix[bombRow][bombCol] = 0;
                    }
                }
            }

            int aliveCells = 0;
            int sumCells = 0;

            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    if (item > 0)
                    {
                        aliveCells++;
                        sumCells += item;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumCells}");
            Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join(" ", r))));

        }
        public static bool GetPosiition(int[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}