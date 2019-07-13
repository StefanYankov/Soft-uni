using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main()
        {
            var bulletSize = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse);
            var locks = Console.ReadLine().Split().Select(int.Parse);
            var value = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>(bullets);
            var locksQueue = new Queue<int>(locks);
            var barrel = barrelSize;

            var counter = 0;

            while (true)
            {
                if (bulletsStack.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                value -= bulletSize;
                bulletsStack.Pop();
                counter++;
                barrel--;

                if (barrel == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrel = barrelSize;
                }

                if (bulletsStack.Count == 0 && locksQueue.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    return;
                }
                else if (bulletsStack.Count >= 0 && locksQueue.Count == 0)
                {
                    Console.WriteLine($"{ bulletsStack.Count} bullets left. Earned ${value}");
                    return;
                }
            }
        }
    }
}


