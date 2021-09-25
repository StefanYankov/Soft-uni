namespace P12CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CupsAndBottlesProgram
    {
        public static void Main()
        {
            int[] inputCupCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> cupsOfWater = new Queue<int>(inputCupCapacity);

            int[] inputBottleCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> bottlesOfWater = new Stack<int>(inputBottleCapacity);

            bool bottlesHaveWater = false;
            bool cupsAreFilled = false;
            int wastedLittersOfWater = 0;

            int currentCup = 0;

            while (true)
            {
                if (cupsOfWater.Count == 0 || bottlesOfWater.Count == 0)
                {

                    if (cupsOfWater.Count == 0 && bottlesOfWater.Count == 0)
                    {
                        bottlesHaveWater = true;
                        cupsAreFilled = true;
                    }
                    else if (cupsOfWater.Count == 0)
                    {
                        cupsAreFilled = true;
                    }
                    else if (bottlesOfWater.Count == 0)
                    {
                        bottlesHaveWater = true;
                    }

                    break;
                }

                int currentBottle = bottlesOfWater.Pop();

                if (currentCup <= 0)
                {
                    currentCup = cupsOfWater.Dequeue();
                }

                while (true)
                {
                    if (currentCup - currentBottle > 0)
                    {
                        currentCup -= currentBottle;
                    }
                    else
                    {
                        wastedLittersOfWater += currentBottle - currentCup;
                        currentCup = 0;
                        break;
                    }



                    if (bottlesOfWater.Count != 0)
                    {
                        currentBottle = bottlesOfWater.Pop();

                    }

                }

            }

            if (cupsAreFilled)
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottlesOfWater)}");
            }
            else if (bottlesHaveWater)
            {
                Console.WriteLine($"Cups: {String.Join(" ", cupsOfWater)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
