﻿namespace P05SpecialNumbers
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool specialNumber = false;
            for (int number = 1; number <= n; number++)
            {
                int sumOfDigits = 0;
                int digits = number;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }

                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    specialNumber = true;
                }
                else
                {
                    specialNumber = false;
                }

                Console.WriteLine($"{number} -> {specialNumber}");
            }
        }
    }
}
