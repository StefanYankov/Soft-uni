namespace P06BombTheBasement
{
    using System;
    using System.Linq;
    using System.Text;
    public class BombTheBasementProgram
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bomb = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int bombRadius = bomb[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));

                    if (distance <= bombRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            int[][] tempMatrix = new int[cols][];

            for (int row = 0; row < cols; row++)
            {
                tempMatrix[row] = new int[rows];

                for (int col = 0; col < rows; col++)
                {
                    tempMatrix[row][col] = matrix[col, row];
                }

                tempMatrix[row] = tempMatrix[row]
                    .OrderByDescending(x => x)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = tempMatrix[col][row];
                }
            }

            Console.WriteLine(PrintMatrix(matrix));
        }

        private static string PrintMatrix(int[,] matrix)
        {
            var sb = new StringBuilder();
            string delimiter = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]).Append(delimiter);
                }

                if (i != (matrix.GetLength(0) - 1))
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}
