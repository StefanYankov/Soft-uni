using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class MatrixShufflingProgram
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] columns = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = columns[col];
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0].ToUpper() == "END")
                {
                    break;
                }

                if (command[0].ToLower() != "swap" || command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstElementRow = int.Parse(command[1]);
                    int firstElementCol = int.Parse(command[2]);
                    int secondElementRow = int.Parse(command[3]);
                    int secondElementCol = int.Parse(command[4]);

                    if (firstElementCol < 0 || firstElementCol > matrix.GetLength(1) 
                        || firstElementRow < 0 || firstElementRow > matrix.GetLength(0) 
                        || secondElementRow < 0 || secondElementRow > matrix.GetLength(0)
                        || secondElementCol < 0 || secondElementCol > matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        var temp = matrix[firstElementRow, firstElementCol];
                        matrix[firstElementRow, firstElementCol] = matrix[secondElementRow, secondElementCol];
                        matrix[secondElementRow, secondElementCol] = temp;

                        for (int row = 0; row < matrixSize[0]; row++)
                        {
                            for (int col = 0; col < matrixSize[1]; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }

            }
        }
    }
}
