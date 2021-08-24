namespace P06JaggedArrayModification
{
    using System;
    using System.Linq;
    using System.Text;
    public class JaggedArrayModificationProgram
    {
        public static void Main()
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixRows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = rowInput;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commands[0];

                if (command.Equals("END"))
                {
                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (!IsValid(row,col,matrix))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }
            }

            Console.WriteLine(PrintMatrix(matrix));
        }

        private static string PrintMatrix(int[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int[] value in matrix)
            {
                sb.AppendLine(string.Join(" ", value));
            }

            return sb.ToString();
        }

        private static bool IsValid(int row, int col, int[][] matrix)
        {
            bool isValid = true;

            if ((row < 0 || row > matrix.Length - 1) || (col < 0 || col > matrix[row].Length - 1))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
