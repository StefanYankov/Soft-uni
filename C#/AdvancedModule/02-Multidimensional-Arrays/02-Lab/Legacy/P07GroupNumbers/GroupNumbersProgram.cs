namespace P07GroupNumbers
{
    using System;
    using System.Linq;
    using System.Text;
    public class GroupNumbersProgram
    {
        public static void Main()
        {
            int[][] matrix = new int[3][];

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix[0] = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            matrix[1] = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            matrix[2] = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(PrintMatrix(matrix));
        }
        private static string PrintMatrix(int[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int[] value in matrix)
            {
                sb.AppendLine(String.Join(" ", value));
            }

            return sb.ToString();
        }
    }
}
