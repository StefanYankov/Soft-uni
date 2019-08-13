using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SeashellTreasure
{
    class Program
    {
        private static char[][] beach;
        static void Main(string[] args)
        {
            List<char> seaShellsList = new List<char>();
            int stolenShellsCount = 0;
            int numberOfRows = int.Parse(Console.ReadLine());
            beach = new char[numberOfRows][];

            InitializeBeach();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (commands[0] != "Sunset")
            {

                if (commands[0] == "Collect")
                {
                    int collectRow = int.Parse(commands[1]);
                    int collectCol = int.Parse(commands[2]);
                    //'C', 'N', 'M' 
                    if (IsInside(collectRow, collectCol))
                    {
                        if (char.IsLetter(beach[collectRow][collectCol]))
                        {
                            seaShellsList.Add(beach[collectRow][collectCol]);
                            beach[collectRow][collectCol] = '-';
                        }

                    }

                }
                else if (commands[0] == "Steal")
                {
                    int collectRow = int.Parse(commands[1]);
                    int collectCol = int.Parse(commands[2]);
                    string direction = commands[3];

                    if (IsInside(collectRow, collectCol))
                    {

                        if (char.IsLetter(beach[collectRow][collectCol]))
                        {
                            stolenShellsCount++;
                            beach[collectRow][collectCol] = '-';
                            for (int move = 1; move <= 3; move++)
                            {
                                if (direction == "up" && IsInside(collectRow -1, collectCol))
                                {
                                    collectRow--;
                                    if (char.IsLetter(beach[collectRow][collectCol]))
                                    {
                                        stolenShellsCount++;
                                        beach[collectRow][collectCol] = '-';
                                    }
                                }
                                else if (direction == "down" && IsInside(collectRow + 1, collectCol))
                                {
                                    collectRow++;
                                    if (char.IsLetter(beach[collectRow][collectCol]))
                                    {
                                        stolenShellsCount++;
                                        beach[collectRow][collectCol] = '-';
                                    }

                                }
                                else if (direction == "left" && IsInside(collectRow, collectCol -1))
                                {
                                    collectCol--;
                                    if (char.IsLetter(beach[collectRow][collectCol]))
                                    {
                                        stolenShellsCount++;
                                        beach[collectRow][collectCol] = '-';
                                    }
                                }
                                else if (direction == "right" && IsInside(collectRow, collectCol + 1))
                                {
                                    collectCol++;
                                    if (char.IsLetter(beach[collectRow][collectCol]))
                                    {
                                        stolenShellsCount++;
                                        beach[collectRow][collectCol] = '-';
                                    }
                                }
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            PrintBeach();

            if (seaShellsList.Count != 0)
            {
                Console.WriteLine($"Collected seashells: {seaShellsList.Count} -> {string.Join(", ", seaShellsList)}");
            }
            else
            {
                Console.WriteLine("Collected seashells: 0");
            }
 
            Console.WriteLine($"Stolen seashells: {stolenShellsCount}");


        }

        private static void PrintBeach()
        {
            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void InitializeBeach()
        {
            for (int row = 0; row < beach.Length; row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                char[] values = string.Join(string.Empty, input).ToCharArray();
                beach[row] = new char[values.Length];

                for (int col = 0; col < values.Length; col++)
                {
                    beach[row][col] = values[col];
                }
            }
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow >= 0 && desiredRow < beach.Length
                                   && desiredCol >= 0 && desiredCol < beach[desiredRow].Length;
        }
    }
}
