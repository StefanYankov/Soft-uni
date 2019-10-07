using System;
using System.Linq;

namespace _3._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine($"{item} => {Math.Round(item, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
