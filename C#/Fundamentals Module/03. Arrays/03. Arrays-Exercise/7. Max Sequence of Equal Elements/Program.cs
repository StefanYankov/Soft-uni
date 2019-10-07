using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int seqLenght = int.Parse(Console.ReadLine());
            string inputDNA = Console.ReadLine();
            int longestSubsequence = -1;
            int longestSubIndex = -1;
            int longestSubSum = -1;

            int[] bestDNA = new int[seqLenght];

            while (inputDNA != "Clone them!")
            {
                int[] numberDNA = inputDNA.Split("!").Select(int.Parse).ToArray();



                inputDNA = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {longestSubIndex} with sum: {longestSubSum}.");
            Console.WriteLine(bestDNA);
        }
    }
}
