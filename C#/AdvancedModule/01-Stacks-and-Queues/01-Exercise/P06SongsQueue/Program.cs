namespace P06SongsQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SongsQueueProgram
    {
        public static void Main()
        {
            string[] songSequence = Console.ReadLine()
                .Split(", ")
                .ToArray();
            Queue<string> songQueue = new Queue<string>(songSequence);
            while (songQueue.Count >0)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];
                switch (command)
                {
                    case "Play":
                        songQueue.Dequeue();
                        break;
                    case "Add":
                        string song = string.Join(" ",commands.Skip(1));
                        if (songQueue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            continue;
                        }
                        songQueue.Enqueue(song);
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songQueue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}