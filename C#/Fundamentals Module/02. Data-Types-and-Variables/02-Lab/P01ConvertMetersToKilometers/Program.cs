namespace P01ConvertMetersToKilometers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int meters = int.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000.0m;
            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
