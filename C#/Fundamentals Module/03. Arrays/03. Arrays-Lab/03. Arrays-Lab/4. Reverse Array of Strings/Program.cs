using System;
using System.Linq;

namespace _4._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().ToArray();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
