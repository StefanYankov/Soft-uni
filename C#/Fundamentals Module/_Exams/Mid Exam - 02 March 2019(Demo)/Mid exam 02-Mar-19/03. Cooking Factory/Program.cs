using System;
using System.Linq;

namespace _03._Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int highestQuality = 0;
            int highestQualityAverage = 0;
            int highestQualityArrayLenght = 0;
            string breadBatch = "";
            while (input != "Bake It!")
            {
                var array = input.Split("#").Select(int.Parse).ToArray();
                int currentArrayLenght = array.Length;
                int currentBatchSum = array.Sum();

                if (currentBatchSum > highestQuality)
                {
                    highestQuality = currentBatchSum;
                    highestQualityAverage = currentBatchSum / currentArrayLenght;
                    highestQualityArrayLenght = currentArrayLenght;
                    breadBatch = input;
                }
                else if (currentBatchSum == highestQuality)
                {
                    if ((currentBatchSum/array.Length) > highestQualityAverage)
                    {
                        highestQuality = currentBatchSum;
                        highestQualityAverage = currentBatchSum / currentArrayLenght;
                        highestQualityArrayLenght = currentArrayLenght;
                        breadBatch = input;
                    }
                    else if ((currentBatchSum / array.Length) == highestQualityAverage)
                    {
                        if (array.Length < highestQualityArrayLenght)
                        {
                            highestQuality = currentBatchSum;
                            highestQualityAverage = currentBatchSum / currentArrayLenght;
                            highestQualityArrayLenght = currentArrayLenght;
                            breadBatch = input;
                        }

                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best Batch quality: {highestQuality}");
            breadBatch = breadBatch.Replace('#', ' ');
            Console.WriteLine(breadBatch);
        }
    }
}
