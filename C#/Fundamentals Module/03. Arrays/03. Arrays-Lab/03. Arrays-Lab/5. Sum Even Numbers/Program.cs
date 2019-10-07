using System;
using System.Linq;

namespace _5._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenNumbers = 0;

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    evenNumbers += item;
                }
            }

            Console.WriteLine(evenNumbers);

        }
    }
}
