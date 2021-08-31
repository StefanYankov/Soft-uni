namespace P04MatrixShuffling
{
    using System;
    using System.Linq;
    using System.Text;
    public class MatrixShufflingProgram
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] columns = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = columns[col];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0].Equals("END"))
                {
                    break;
                }

                string command = input[0];

                if (!command.Equals("swap") || input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                if (NotValid(row1, col1, row2, col2, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;
                Console.WriteLine(PrintMatrix(matrix));

            }
        }

        private static string PrintMatrix(string[,] matrix)
        {
            var sb = new StringBuilder();
            string delimiter = " ";
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
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

        private static bool NotValid(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            bool isValid = (
                col1 < 0 || col1 > matrix.GetLength(1)
                         || row1 < 0 || row1 > matrix.GetLength(0)
                         || row2 < 0 || row2 > matrix.GetLength(0)
                         || col2 < 0 || col2 > matrix.GetLength(1));

            return isValid;
        }
    }
}
