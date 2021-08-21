namespace P11PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PoisonousPlantsProgram
    {
        public static void Main()
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] days = new int[plants.Length];
            Stack<int> proximityStack = new Stack<int>();
            proximityStack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
                }
                if (proximityStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                proximityStack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
