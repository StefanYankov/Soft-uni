namespace P03PrimaryDiagonal
{
    using System;
    using System.Linq;
    public class PrimaryDiagonalProgram
    {
        public static void Main()
        {
            int squareMatrixSide = int.Parse(Console.ReadLine());
            int primaryDiagonalSum = 0;
            int[,] matrix = new int[squareMatrixSide, squareMatrixSide];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int tempElement = colElements[col];
                    matrix[row, col] = tempElement;
                    if (row == col)
                    {
                        primaryDiagonalSum += tempElement;
                    }
                }
            }
            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
