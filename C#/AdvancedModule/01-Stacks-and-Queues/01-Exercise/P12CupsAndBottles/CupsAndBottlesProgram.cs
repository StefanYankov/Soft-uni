namespace P12CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CupsAndBottlesProgram
    {
        public static void Main()
        {
            int[] cupCapacityInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] bottlesOfWaterInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupCapacityInput);
            Stack<int> bottles = new Stack<int>(bottlesOfWaterInput);
            int wastedLiters = 0;
            int currentCup = 0;

            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
                    break;
                }

                if (bottles.Count == 0)
                {
                    if (currentCup <= 0)
                    {
                        Console.WriteLine($"Cups: {String.Join(" ",cups)}");
                    }
                    else
                    {
                        cups.Dequeue();
                        Console.WriteLine($"Cups: {currentCup} {String.Join(" ", cups)}");
                    }
             
                    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
                    break;
                }

                int currentBottle = bottles.Pop();

                if (currentCup <= 0)
                {
                    currentCup = cups.Peek();
                }

                if ((currentCup - currentBottle) > 0)
                {
                    currentCup -= currentBottle;
                }
                else if (currentBottle == currentCup)
                {
                    currentCup -= currentBottle;
                    cups.Dequeue();
                }
                else if ((currentCup - currentBottle) < 0)
                {
                    wastedLiters += currentBottle - currentCup;
                    currentCup -= currentBottle;
                    cups.Dequeue();
                }
            }
        }
    }
}
