namespace P05SnakeMoves
{
    using System;
    using System.Linq;
    using System.Text;
    public class SnakeMovesProgram
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] isle = new char[dimensions[0], dimensions[1]];
            char[] snake = Console.ReadLine().ToCharArray();
            int counter = 0;

            for (int row = 0; row < isle.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < isle.GetLength(1); col++)
                    {
                        isle[row, col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = isle.GetLength(1) - 1; col >= 0; col--)
                    {
                        isle[row, col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
            }
            Console.WriteLine(PrintMatrix(isle));
        }

        private static string PrintMatrix(char[,] matrix)
        {
            var sb = new StringBuilder();
            string delimiter = string.Empty;
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
    }
}
