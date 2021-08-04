namespace P03ExactSumOfRealNumbers
{
    using System;

    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
