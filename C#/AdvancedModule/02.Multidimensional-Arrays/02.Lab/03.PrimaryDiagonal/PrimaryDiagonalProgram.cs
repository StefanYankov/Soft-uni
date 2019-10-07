using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class PrimaryDiagonalProgram
    {
        static void Main()
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareSize, squareSize];

            int diagonalSum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] col = Console.ReadLine()
                    .Split()
                    .Select(int.Parse).
                    ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = col[c];
                    if (r == c)
                    {
                        diagonalSum += col[c];
                    }
                }
            }

            Console.WriteLine(diagonalSum);

        }
    }
}
