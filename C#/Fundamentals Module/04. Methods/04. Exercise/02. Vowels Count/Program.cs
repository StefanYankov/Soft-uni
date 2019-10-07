using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();

            Console.WriteLine(VowelsCount(input));
        }

        static int VowelsCount(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                // A, E, I, O, U,

                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    counter++;
                }

            }
            return counter;
        }

    }
}
