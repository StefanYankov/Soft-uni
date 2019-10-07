using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class DiagonalDifferenceProgram
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] column = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        matrix[r, c] = column[c];
                        if (r == c)
                        {
                            primaryDiagonalSum += column[c];
                        }
                    }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                secondaryDiagonalSum += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
