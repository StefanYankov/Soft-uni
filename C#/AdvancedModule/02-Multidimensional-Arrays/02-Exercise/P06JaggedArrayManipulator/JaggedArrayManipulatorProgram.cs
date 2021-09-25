namespace P06JaggedArrayManipulator
{
    using System;
    using System.Linq;
    using System.Text;
    public class JaggedArrayManipulatorProgram
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                    .ToArray();
                jaggedArray[i] = input;
            }

            //analyze
            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    RowMultiplier(jaggedArray, i);
                }
                else
                {
                    RowDivider(jaggedArray, i);
                }
            }

            //commands
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                if (command.Equals("End"))
                {
                    break;
                }

                if (input.Length != 4)
                {
                    continue;
                }

                if (command.Equals("Add"))
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (IndexesAreValid(row, col, jaggedArray))
                    {
                        jaggedArray[row][col] += value;
                    }

                }
                else if (command.Equals("Subtract"))
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);
                    if (IndexesAreValid(row, col, jaggedArray))
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

            }
            //print
            Console.WriteLine(PrintJaggedArray(jaggedArray));
        }

        private static void RowMultiplier(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] = jaggedArray[row][i] * 2;
            }

            for (int j = 0; j < jaggedArray[row + 1].Length; j++)
            {
                jaggedArray[row + 1][j] = jaggedArray[row + 1][j] * 2;
            }
        }

        private static void RowDivider(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] = jaggedArray[row][i] / 2;
            }

            for (int i = 0; i < jaggedArray[row + 1].Length; i++)
            {
                jaggedArray[row + 1][i] = jaggedArray[row + 1][i] / 2;
            }
        }

        private static bool IndexesAreValid(int row, int col, double[][] jaggedArray)
        {
            bool isValid = true;

            if (row < 0 || col < 0 || row >= jaggedArray.Length || col >= jaggedArray[row].Length)
            {
                isValid = false;
            }

            return isValid;
        }

        private static string PrintJaggedArray(double[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (double[] value in matrix)
            {
                sb.AppendLine(string.Join(" ", value));
            }

            return sb.ToString();
        }
    }
}
