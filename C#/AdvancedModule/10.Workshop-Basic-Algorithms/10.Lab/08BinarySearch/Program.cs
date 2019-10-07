using System;
using System.Collections.Generic;

namespace _08BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 5, 10, 15, 18, 20, 22, 150, 300, 345, 567, 1024 };

            Console.WriteLine(BinarySearch(numbers, 5, 0, numbers.Length -1));
        }

        public static int BinarySearch(int[] numbers, int key, int start, int end)
        {
            while (start <= end)
            {
                var mid = (start + end) / 2;
                if (numbers[mid] > key)
                {
                    end = mid - 1;
                }
                else if (numbers[mid] < key)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return 1;
        }
    }
}
