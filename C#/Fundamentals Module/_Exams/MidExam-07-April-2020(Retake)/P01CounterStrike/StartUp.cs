using System;

namespace P01CounterStrike
{
    public class StartUp
    {
        public static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            string input;
            int battlesWon = 0;
            bool hasFailed = false;
            while (!(input = Console.ReadLine()).Equals("End of battle"))
            {
                int distance = int.Parse(input);
                if ((energy - distance) < 0)
                {
                    hasFailed = true;
                    break;
                }
                energy -= distance;
                battlesWon++;
                if (battlesWon % 3 == 0)
                {
                    energy += battlesWon;
                }
            }

            if (hasFailed)
            {
                Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
            }
        }
    }
}
