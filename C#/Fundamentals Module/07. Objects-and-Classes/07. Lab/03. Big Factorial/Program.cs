﻿using System;
using System.Numerics;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 1; i <= input; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
