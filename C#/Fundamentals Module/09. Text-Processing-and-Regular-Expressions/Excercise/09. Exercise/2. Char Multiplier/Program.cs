using System;

namespace _2._Char_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userInput = Console.ReadLine()
                .Split();
            string firstWord = userInput[0];
            string secondWord = userInput[1];

            string longerWord = String.Empty;
            string shorterWord = String.Empty;

            int sum = 0;

            if (firstWord.Length >= secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;
            }
            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                sum += longerWord[i] * shorterWord[i];
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }
            Console.WriteLine(sum);
        }
    }
}
