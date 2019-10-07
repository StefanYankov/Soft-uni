using System;
using System.Linq;

namespace _09.Miner
{
    public class MinerProgram
    {
        static void Main()
        {
            int fieldSizeSide = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSizeSide, fieldSizeSide];

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int coalCount = 0;
            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] fieldRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fieldRow[col];

                    if (field[row, col] == 'c')
                    {
                        coalCount++;
                    }
                    if (field[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            field[currentRow, currentCol] = '*';

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            currentRow -= 1;
                        }
                        break;
                    case "right":
                        if (currentCol + 1 < field.GetLength(1))
                        {
                            currentCol += 1;
                        }
                        break;
                    case "down":
                        if (currentRow + 1 < field.GetLength(0))
                        {
                            currentRow += 1;
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            currentCol -= 1;
                        }
                        break;
                }

                if (field[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
                if (field[currentRow, currentCol] == 'c')
                {
                    coalCount--;
                    field[currentRow, currentCol] = '*';
                }
                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    return;
                }
            }
            Console.WriteLine($"{coalCount} coals left. ({currentRow}, {currentCol})");
        }
    }
}