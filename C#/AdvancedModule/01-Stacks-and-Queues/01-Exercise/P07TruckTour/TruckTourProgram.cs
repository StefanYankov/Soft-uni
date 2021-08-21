namespace P07TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TruckTourProgram
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            int fuel = 0;
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] petrolPumpInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int pumpCapacity = petrolPumpInfo[0];
                int distance = petrolPumpInfo[1];

                fuel += pumpCapacity;

                if (fuel >= distance)
                {
                    queue.Enqueue(i);
                    fuel -= distance;
                }
                else
                {
                    queue.Clear();
                    fuel = 0;
                }
            }
            Console.WriteLine(queue.Min());
        }
    }
}
