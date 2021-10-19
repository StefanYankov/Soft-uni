namespace P02KnightsOfHonor
{
    using System;
    using System.Linq;
    public class KnightsOfHonorProgram
    {
        public static void Main()
        {
            Action<string[]> printNames = names => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] inputNames = Console.ReadLine().Split(' ').ToArray();

            printNames(inputNames);
        }
    }
}
