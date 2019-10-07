using System;

namespace _3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToBeRemoved = Console.ReadLine();
            string inputString = Console.ReadLine();

            while (inputString.Contains(wordToBeRemoved))
            {
                inputString = inputString.Replace(wordToBeRemoved, string.Empty);
            }
            Console.WriteLine(inputString);

        }
    }
}
