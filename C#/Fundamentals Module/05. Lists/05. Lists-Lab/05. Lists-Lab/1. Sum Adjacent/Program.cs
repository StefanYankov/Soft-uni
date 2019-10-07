using System;
using System.Collections.Generic;

namespace _1._Sum_Adjacent
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 1, 2, 3 };

            List<int> numbers = new List<int>(array);
            numbers.Add(4);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------");

            numbers.Remove(3);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }


        }
    }
}
