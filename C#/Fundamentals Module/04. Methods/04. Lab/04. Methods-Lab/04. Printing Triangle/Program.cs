using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
            PrintReverseTriangle(number - 1);
        }

        private static void PrintTriangle(int maxNumber)
        {
            for (int row = 1; row <= maxNumber; row++)
            {
                PrintRowWithNumbers(row);
            }
        }

        private static void PrintReverseTriangle(int maxNumber)
        {
            for (int row = maxNumber; row >= 1; row--)
            {
                PrintRowWithNumbers(row);
            }

        }

        private static void PrintRowWithNumbers(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col + " ");
            }

            Console.WriteLine();
        }

    }
}
