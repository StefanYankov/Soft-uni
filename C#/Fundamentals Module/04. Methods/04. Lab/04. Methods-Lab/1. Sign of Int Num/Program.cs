using System;

namespace _01._Sign_of_Int_Num
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSign(int.Parse(Console.ReadLine()));   
        }

        static void PrintSign(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
            else
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }
    }
}
