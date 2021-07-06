using System;
using System.Collections.Generic;
using System.Linq;

namespace P03Numbers

{
    public class StartUp
    {
        public static void Main()
        {
            List<int> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double average = input.Average();
            List<int> aboveAverageList = input.FindAll(x => x > average).OrderByDescending(x=>x).ToList();

            if (aboveAverageList.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine(String.Join(' ', aboveAverageList.Take(5)));

        }
    }
}
