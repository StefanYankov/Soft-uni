using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintingMiddleChars(input);

        }

        private static void PrintingMiddleChars(string input)
        {
            if (input.Length % 2 == 0)
            {
                //1234
                Console.WriteLine($"{input[input.Length/2 - 1]}{input[input.Length/2]}");
            }
            else
            {
                //123
                Console.WriteLine($"{input[input.Length/2]}");
            }
        }
    }
}
