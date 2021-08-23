namespace P01SumMatrixElements
{
    using System;
    using System.Linq;
    public class SumMatrixElementsProgram
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalSum = 0;
            int[,] matrix = new int[size[0], size[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int tempElement = colElements[col];

                    matrix[row, col] = tempElement;
                    totalSum += tempElement;
                }   
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
        }
    }
}
