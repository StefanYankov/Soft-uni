using System;
using System.Linq;

namespace oldPoisonousPlants
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < plants.Length - 1; i++)
            {
                if (plants[i] < plants[i + 1])
                {

                }

            }
        }
    }
}
