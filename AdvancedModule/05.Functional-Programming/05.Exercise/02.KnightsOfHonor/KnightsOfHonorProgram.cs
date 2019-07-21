using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonorProgram
    {
        static void Main()
        {
            Action<string[]> printNames = names => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] inputNames = Console.ReadLine().Split(' ').ToArray();

            printNames(inputNames);
        }
    }
}
