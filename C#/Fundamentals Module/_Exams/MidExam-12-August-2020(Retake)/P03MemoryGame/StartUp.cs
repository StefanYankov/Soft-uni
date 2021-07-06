using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MemoryGame
{

   public class StartUp
    {
        public static void Main()
        {
            List<string> sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            int counter = 0;

            while (!command.Equals("end"))
            {
                counter++;

                string[] indexes = command.Split();
                int firstIndex = int.Parse(indexes[0]);
                int secondIndex = int.Parse(indexes[1]);



                if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < sequence.Count && secondIndex < sequence.Count && firstIndex != secondIndex)
                {
                    if (sequence[firstIndex] == sequence[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");

                        if (firstIndex > secondIndex)
                        {
                            sequence.RemoveAt(firstIndex);
                            sequence.RemoveAt(secondIndex);
                        }
                        else
                        {
                            sequence.RemoveAt(secondIndex);
                            sequence.RemoveAt(firstIndex);
                        }

                        if (sequence.Count == 0)
                        {
                            Console.WriteLine($"You have won in {counter} turns!");
                            return;
                        }
                    }
                    else if (sequence[firstIndex] != sequence[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    sequence.Insert(sequence.Count / 2, $"-{counter}a");
                    sequence.Insert(sequence.Count / 2, $"-{counter}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(String.Join(" ", sequence));
        }
    }
}
