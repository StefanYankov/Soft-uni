using System.Linq;

namespace P05FashionBoutique
{
    using System;
    using System.Collections.Generic;
    public class FashionBoutiqueProgram
    {
        public static void Main()
        {
            int currentClothesCapacity = 0;
            int countOfRacks = 1;
            int[] deliveredClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> deliveryBox = new Stack<int>(deliveredClothes);
            int capacityRack = int.Parse(Console.ReadLine());

            while (true)
            {
                if (deliveryBox.Count == 0)
                {
                    break;
                }

                int currentCloth = deliveryBox.Pop();
                if ((currentClothesCapacity + currentCloth) > capacityRack)
                {
                    countOfRacks++;
                    currentClothesCapacity = currentCloth;
                    continue;
                }

                currentClothesCapacity += currentCloth;
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
