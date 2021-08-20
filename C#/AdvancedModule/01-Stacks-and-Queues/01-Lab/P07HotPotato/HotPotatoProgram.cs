namespace P07HotPotato
{
    using System;
    using System.Collections.Generic;
    public class HotPotatoProgram
    {
        public static void Main()
        {
            string[] participants = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = int.Parse(Console.ReadLine());
            int counter = 0;
            Queue<string> hotPotatoGame = new Queue<string>(participants);
            while (hotPotatoGame.Count > 1)
            {
                var temp = hotPotatoGame.Dequeue();
                counter++;
                if (counter % count == 0)
                {
                    Console.WriteLine($"Removed {temp}");
                }
                else
                {
                    hotPotatoGame.Enqueue(temp);
                }
            }
            Console.WriteLine($"Last is {hotPotatoGame.Peek()}");
        }
    }
}
