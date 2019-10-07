using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class JaggedArrayModificationProgram
    {
        static void Main()
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRows][];

            for (int r = 0; r < matrixRows; r++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[r] = row;
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if ((row <0 || row > (matrix.Length - 1)) || column < 0 || column > matrix[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                    continue;
                }

                switch (command[0])
                {
                    case "Add":
                        matrix[row][column] += value;
                        break;
                    case "Subtract":
                        matrix[row][column] -= value;
                        break;
                    default:
                        break;
                }
                //    if (command[0] == "add")
                //    {
                //        int currentvalue = matrix[row][column];
                //        matrix[row][column] = currentvalue + value;

                //    }
                //    else if (command[0] == "subtract")
                //    {
                //        int currentvalue = matrix[row][column];
                //        matrix[row][column] = currentvalue - value;
                //    }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));

            }

        }
    }
}
