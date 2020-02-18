using System;
using System.Linq;

namespace P03_JediGalaxy
{
   public class Engine
    {

        //1:43:51
        public void Run()
        {
            int[] dimensions = Console.ReadLine()
       .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
       .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().
                    Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int playerRow = playerCoordinates[0];
                int playerCow = playerCoordinates[1];

                while (playerRow >= 0 && playerCow < matrix.GetLength(1))
                {
                    if (playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCow >= 0 && playerCow < matrix.GetLength(1))
                    {
                        sum += matrix[playerRow, playerCow];
                    }

                    playerCow++;
                    playerRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
