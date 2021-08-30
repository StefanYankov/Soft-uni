namespace P01DiagonalDifference
{
    using System;
    using System.Linq;
    public class DiagonalDifferenceProgram
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j]; 

                    if (i == j)
                    {
                        primaryDiagonalSum += matrix[i, j];
                    }

                    if ((i + j) == (matrixSize - 1))
                    {
                        secondaryDiagonalSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum- secondaryDiagonalSum));
        }
    }
}
