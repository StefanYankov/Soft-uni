using System;
using System.Linq;

namespace P03HeartDelivery
{
    public class StartUp
    {
        public static void Main()
        {
            int[] neighborhood = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input;
            int lastPositionIndex = 0;

            while (!((input=Console.ReadLine()).Equals("Love!")))
            {
                int index = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                int nextIndex = lastPositionIndex + index;

                if(nextIndex >= neighborhood.Length)
                {
                    nextIndex = 0;
                }

                if (neighborhood[nextIndex] == 0)
                {
                    Console.WriteLine($"Place {nextIndex} already had Valentine's day.");
                    lastPositionIndex = nextIndex;
                    continue;
                }

                neighborhood[nextIndex] -= 2;

                if (neighborhood[nextIndex] == 0)
                {
                    Console.WriteLine($"Place {nextIndex} has Valentine's day.");
                }
                lastPositionIndex = nextIndex;
            }

            Console.WriteLine($"Cupid's last position was {lastPositionIndex}.");

            if (neighborhood.All(x => x == 0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Count(x => x != 0)} places.");
            }
        }
    }
}
