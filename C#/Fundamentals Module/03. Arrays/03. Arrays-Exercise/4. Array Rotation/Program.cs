using System;
using System.Linq;

namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotator = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotator; i++)
            {
                int firstNumber = arr[0];

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = firstNumber;


            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
