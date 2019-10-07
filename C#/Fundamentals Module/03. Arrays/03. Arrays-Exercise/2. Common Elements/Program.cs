using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArray = Console.ReadLine().Split().ToArray();
            var secondArray = Console.ReadLine().Split().ToArray();
            List<string> commonList = new List<string>();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        commonList.Add(secondArray[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", commonList));
        }
    }
}
