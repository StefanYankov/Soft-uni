using System;
using System.Linq;

namespace _02._2x2SquaresInMatrix
{
    class TwoByTwoSquaresInMatrix
    {
        static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var columns = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r,c] = columns[c];
                }
            }

            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    if (matrix[r, c] == matrix[r, c + 1]  
                        && matrix[r, c + 1] == matrix[r + 1, c] 
                        && matrix[r + 1, c] == matrix[r + 1, c + 1])
                    {
                        count++;
                    }

                }

            }
            Console.WriteLine(count);
        }
    }
}
