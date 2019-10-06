using System;

namespace _07BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 4, 2, 5, 6 };
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int tempNumber = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = tempNumber;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
