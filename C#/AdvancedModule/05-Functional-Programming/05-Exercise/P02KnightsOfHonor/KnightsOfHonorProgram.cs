namespace P02KnightsOfHonor
{
    using System;
    using System.Linq;
    public class KnightsOfHonorProgram
    {
        public static void Main()
        {
            Action<string> printAddSir = text => text
                .Split()
                .ToList()
                .ForEach(x => Console.WriteLine($"Sir {x}"));

            string text = Console.ReadLine();

            printAddSir(text);
        }
    }
}
