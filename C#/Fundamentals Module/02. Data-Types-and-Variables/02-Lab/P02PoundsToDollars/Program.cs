namespace P02PoundsToDollars
{
    using System;
    public class Program
    {
        public static void Main()
        {
            double pounds = double.Parse(Console.ReadLine());
            double dollars = pounds * 1.31;
            Console.WriteLine($"{dollars:F3}");
        }
    }
}
