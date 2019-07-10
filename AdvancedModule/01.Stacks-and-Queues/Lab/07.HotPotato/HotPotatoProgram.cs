using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main()
        {
            //Mimi Pepi Toshko
            string[] participants = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int tosses = int.Parse(Console.ReadLine());

            Queue<string> game = new Queue<string>(participants);

            while (game.Count != 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    game.Enqueue(game.Dequeue());
                }

                Console.WriteLine($"Removed {game.Dequeue()}");
            }

            Console.WriteLine($"Last is {game.Dequeue()}");
        }
    }
}
