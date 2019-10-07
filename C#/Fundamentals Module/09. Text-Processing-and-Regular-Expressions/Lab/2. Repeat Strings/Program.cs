using System;

namespace _2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            string output = String.Empty;

            foreach (var word in words)
            {
                int repeatCount = word.Length;
                for (int i = 1; i <= repeatCount; i++)
                {
                    output += word;
                }
            }
            Console.WriteLine(output);
        }
    }
}
