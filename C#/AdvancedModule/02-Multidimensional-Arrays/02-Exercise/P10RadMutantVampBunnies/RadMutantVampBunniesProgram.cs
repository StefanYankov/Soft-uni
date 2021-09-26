namespace P10RadMutantVampBunnies
{
    using System;
    using System.Text;
    using System.Linq;
    public class RadMutantVampBunniesProgram
    {
        public static void Main()
        {
            int[] fieldSideSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            char[,] field = new char[fieldSideSize[0], fieldSideSize[1]];
            int currentRow = -1;
            int currentCol = -1;
            bool hasWon = true;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = input[j];
                    if (input[j].Equals('P'))
                    {
                        currentRow = i;
                        currentCol = j;
                        field[i, j] = '.';
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];

                int newPlayerRow = currentRow;
                int newPlayerCol = currentCol;
                switch (currentCommand)
                {
                    case 'L':
                        newPlayerCol -= 1;
                        break;
                    case 'R':
                        newPlayerCol += 1;
                        break;
                    case 'U':
                        newPlayerRow -= 1;
                        break;
                    case 'D':
                        newPlayerRow += 1;
                        break;
                }
                field = MultiplyBunnies(field);

                if (newPlayerRow >= 0 && newPlayerRow < field.GetLength(0)
                                      && newPlayerCol >= 0 && newPlayerCol < field.GetLength(1))
                {
                    currentRow = newPlayerRow;
                    currentCol = newPlayerCol;

                    if (field[currentRow, currentCol] == 'B')
                    {
                        hasWon = false;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(PrintMatrix(field));
            if (hasWon)
            {
                Console.WriteLine($"won: {currentRow} {currentCol}");
            }
            else
            {
                Console.WriteLine($"dead: {currentRow} {currentCol}");
            }
        }

        public static char[,] MultiplyBunnies(char[,] field)
        {
            char[,] tempField = (char[,])field.Clone();
            int rowCount = field.GetLength(0);
            int colCount = field.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (field[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            tempField[row - 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            tempField[row, col - 1] = 'B';
                        }
                        if (col + 1 < colCount)
                        {
                            tempField[row, col + 1] = 'B';
                        }
                        if (row + 1 < rowCount)
                        {
                            tempField[row + 1, col] = 'B';
                        }
                    }
                }
            }
            return tempField;

        }

        private static string PrintMatrix(char[,] matrix)
        {
            var sb = new StringBuilder();
            string delimiter = "";
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
