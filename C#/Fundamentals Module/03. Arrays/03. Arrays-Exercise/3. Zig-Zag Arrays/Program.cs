using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());
            var leftNumber = new int[numberOfInput];
            var rightNumber = new int[numberOfInput];

            for (int i = 0; i < numberOfInput; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    leftNumber[i] = input[0];
                    rightNumber[i] = input[1];
                }
                else
                {
                    leftNumber[i] = input[1];
                    rightNumber[i] = input[0];
                }
            }
            Console.WriteLine(string.Join(" ",leftNumber));
            Console.WriteLine(string.Join(" ",rightNumber));
        }
    }
}

