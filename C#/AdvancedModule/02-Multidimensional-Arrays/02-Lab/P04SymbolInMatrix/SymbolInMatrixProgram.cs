namespace P04SymbolInMatrix
{
    using System;
    public class SymbolInMatrixProgram
    {
        public static void Main()
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareSize, squareSize];


            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] col = Console.ReadLine()
                    .ToCharArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = col[c];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{ symbol} does not occur in the matrix");
        }
    }
}
