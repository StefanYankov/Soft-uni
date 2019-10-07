using System;
using System.Linq;

namespace _6._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenNumbers = 0;
            int oddNumbers = 0;
            int result = 0;

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers += number;
                }
                else
                {
                    oddNumbers += number;
                }
            }

            Console.WriteLine(evenNumbers - oddNumbers);
        }
    }
}
