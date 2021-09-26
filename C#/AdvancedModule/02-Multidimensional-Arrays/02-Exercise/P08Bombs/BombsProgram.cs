namespace P08Bombs
{
    using System;
    using System.Linq;
    using System.Text;
    public class BombsProgram
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i ++)
            {
                int[] currentCoordinates = coordinates[i].Split(',').Select(int.Parse).ToArray();
                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];

                if (!IsValidCoordinates(currentRow, currentCol, matrix))
                {
                    continue;
                }

                if (matrix[currentRow,currentCol] <= 0)
                {
                    continue;
                }

                int bombDamage = matrix[currentRow, currentCol];
                matrix[currentRow, currentCol] = 0;
                // prev row
                if (IsValidCoordinates(currentRow - 1,currentCol-1,matrix))
                {
                    if (matrix[currentRow-1,currentCol -1] > 0)
                    {
                        matrix[currentRow - 1, currentCol - 1] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow - 1, currentCol, matrix))
                {
                    if (matrix[currentRow - 1, currentCol] > 0)
                    {
                        matrix[currentRow - 1, currentCol] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow - 1, currentCol + 1, matrix))
                {
                    if (matrix[currentRow - 1, currentCol + 1] > 0)
                    {
                        matrix[currentRow - 1, currentCol + 1] -= bombDamage;
                    }
                }
                // curr row
                if (IsValidCoordinates(currentRow, currentCol - 1, matrix))
                {
                    if (matrix[currentRow, currentCol - 1] > 0)
                    {
                        matrix[currentRow, currentCol - 1] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow, currentCol, matrix))
                {
                    if (matrix[currentRow, currentCol] > 0)
                    {
                        matrix[currentRow, currentCol] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow, currentCol + 1, matrix))
                {
                    if (matrix[currentRow, currentCol + 1] > 0)
                    {
                        matrix[currentRow, currentCol + 1] -= bombDamage;
                    }
                }
                // next row
                if (IsValidCoordinates(currentRow + 1, currentCol - 1, matrix))
                {
                    if (matrix[currentRow + 1, currentCol - 1] > 0)
                    {
                        matrix[currentRow + 1, currentCol - 1] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow + 1, currentCol, matrix))
                {
                    if (matrix[currentRow + 1, currentCol] > 0)
                    {
                        matrix[currentRow + 1, currentCol] -= bombDamage;
                    }
                }
                if (IsValidCoordinates(currentRow + 1, currentCol + 1, matrix))
                {
                    if (matrix[currentRow + 1, currentCol + 1] > 0)
                    {
                        matrix[currentRow + 1, currentCol + 1] -= bombDamage;
                    }
                }
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
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
            Console.WriteLine(sb.ToString());
        }
        private static bool IsValidCoordinates(int currentRow, int currentCol, int[,] matrix)
        {
            bool isValid = true;

            if (currentRow < 0 || currentCol < 0 || currentRow >= matrix.GetLength(0) || currentCol >= matrix.GetLength(1))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
