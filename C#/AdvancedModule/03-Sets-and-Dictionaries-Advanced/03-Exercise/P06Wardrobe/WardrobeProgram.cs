namespace P06Wardrobe
{
    using System;
    using System.Collections.Generic;
    public class WardrobeProgram
    {
        public static void Main()
        {
            int numberOfClothesByColors = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < numberOfClothesByColors; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothe in clothes)
                {

                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe, 0);
                    }

                    wardrobe[color][clothe]++;
                }

            }

            string[] targetClothInfo = Console.ReadLine().Split(' ');
            string targetColor = targetClothInfo[0];
            string targetCloth = targetClothInfo[1];
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                if (color.Key.Equals(targetColor))
                {
                    foreach (var clothe in color.Value)
                    {
                        if (clothe.Key.Equals(targetCloth))
                        {
                            Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {clothe.Key} - {clothe.Value}");

                        }
                    }
                }
                else
                {
                    foreach (var clothe in color.Value)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }

            }

        }
    }
}
