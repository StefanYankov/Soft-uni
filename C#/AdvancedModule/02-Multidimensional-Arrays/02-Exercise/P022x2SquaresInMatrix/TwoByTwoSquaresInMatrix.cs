namespace P022x2SquaresInMatrix
{
    using System;
    using System.Linq;
    public class TwoByTwoSquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowCount = dimensions[0];
            int colCount = dimensions[1];
            char[,] matrix = new char[rowCount, colCount];
            int countOfEqualCharMatrixes = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1]
                        && matrix[i, j + 1] == matrix[i + 1, j]
                        && matrix[i + 1, j] == matrix[i + 1, j + 1])
                    {
                        countOfEqualCharMatrixes++;
                    }
                }
            }
            Console.WriteLine(countOfEqualCharMatrixes);
        }
    }
}
