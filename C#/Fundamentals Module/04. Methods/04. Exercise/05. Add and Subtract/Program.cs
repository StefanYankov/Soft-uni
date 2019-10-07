using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            Console.WriteLine(SubtractThird(SumFirstAndSecond(firstInt, secondInt), thirdInt));
        }

        private static int SubtractThird(int v, int thirdInt)
        {
            return v - thirdInt;
        }

        private static int SumFirstAndSecond(int firstInt, int secondInt)
        {
            return firstInt + secondInt;
        }
    }
}
