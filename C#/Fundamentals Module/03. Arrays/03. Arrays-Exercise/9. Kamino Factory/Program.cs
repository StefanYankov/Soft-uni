using System;
using System.Linq;

namespace _9._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int longestSubSeq = -1;
            int longestSubIndex = -1;
            int longestSubSum = 0;
            int[] sequence = new int[length];

            string input = Console.ReadLine();

            while (input != "Clone them!")
            {
                int[] currentSequence = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int subSeq = -1;
                int subIndex = -1;
                int subSum = 0;

                if 

                input = Console.ReadLine();
            }

        }
    }
}
