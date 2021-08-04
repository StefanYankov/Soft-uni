namespace P07WaterOverflow
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            const int Capacity = 255;
            int currentVolume = 0;
            int input;
            for (int i = 0; i < numberOfLines; i++)
            {
                input = int.Parse(Console.ReadLine());
                if ((currentVolume + input) <= Capacity)
                {
                    currentVolume += input;
                    continue;
                }

                Console.WriteLine($"Insufficient capacity!");
            }

            Console.WriteLine(currentVolume);
        }
    }
}
