using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
