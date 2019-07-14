using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main()
        {
            var boxOfClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> rack = new Stack<int>(boxOfClothes); //5 4 8 6 3 8 7 7 9

            int rackCount = 1;
            int clothesSum = 0;
            int initialRackCount = rack.Count;

            for (int i = 0; i < initialRackCount; i++)
            {
                if ((clothesSum + rack.Peek()) <= rackCapacity)
                {
                    clothesSum += rack.Pop();
                }
                else
                {
                    rackCount++;
                    clothesSum = 0;
                    clothesSum += rack.Pop();
                }
            }

            Console.WriteLine(rackCount);

        }
    }
}
