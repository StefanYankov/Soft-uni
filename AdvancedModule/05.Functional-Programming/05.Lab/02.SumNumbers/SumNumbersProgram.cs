﻿using System;
using System.Linq;

namespace _02.SumNumbers
{
    class SumNumbersProgram
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = x => int.Parse(x);
            int[] numbers = input.Split(',',StringSplitOptions.RemoveEmptyEntries)
                       .Select(parser).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());

        }
    }
}
