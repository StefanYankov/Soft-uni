using System;
using System.Linq;

namespace _4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfInts = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();

            if (listOfInts.Length < 3)
            {
                foreach (var item in listOfInts)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(listOfInts[i] + " ");
                }
            }

            Console.WriteLine();


        }
    }
}
