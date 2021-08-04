namespace P08BeerKegs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> kegDictionary = new Dictionary<string, decimal>();
            string model;
            decimal radius;
            int height;
            decimal volume;
            for (int i = 0; i < numberOfKegs; i++)
            {
                model = Console.ReadLine();
                radius = decimal.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());
                volume = (decimal)Math.PI * (radius * radius) * (decimal)height;
                kegDictionary.Add(model, volume);
            }

            Console.WriteLine(kegDictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key);
        }
    }
}
