namespace P09Miner
{
    using System;
    using System.Linq;
    public class MinerProgram
    {
        public static void Main()
        {
            int fieldSideSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSideSize, fieldSideSize];

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int currentRow = -1;
            int currentCol = -1;
            int countOfCoal = 0;
            bool noMoreCommands = false;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = input[j];
                    if (input[j].Equals('s'))
                    {
                        currentRow = i;
                        currentCol = j;
                    }

                    if (input[j].Equals('c'))
                    {
                        countOfCoal++;
                    }
                }
            }
            field[currentRow, currentCol] = '*';

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                switch (command)
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

                if (field[currentRow, currentCol].Equals('e'))
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    noMoreCommands = true;
                    break;
                }
                
                if (field[currentRow, currentCol].Equals('c'))
                {
                    countOfCoal--;
                    field[currentRow, currentCol] = '*';
                }
                
                if (countOfCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    noMoreCommands = true;
                    break;
                }
            }

            if (!noMoreCommands)
            {
                Console.WriteLine($"{countOfCoal} coals left. ({currentRow}, {currentCol})");
            }
        }
    }
}
