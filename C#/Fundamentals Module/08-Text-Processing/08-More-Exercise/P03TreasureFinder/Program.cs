namespace P03TreasureFinder
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            int keyCurrentIndex = 0;

            while (!((input = Console.ReadLine()).Equals("find")))
            {
                char[] charArr = input.ToCharArray();

                for (int i = 0; i < charArr.Length; i++)
                {
                    char currentChar = charArr[i];
                    char charToAdd = (char)((int)currentChar - key[keyCurrentIndex]);
                    charArr[i] = charToAdd;

                    keyCurrentIndex++;
                    if (keyCurrentIndex == key.Length)
                    {
                        keyCurrentIndex = 0;
                    }

                }

                string outputString = new string(charArr);
                int firstWordStartIndex = outputString.IndexOf('&') +1;

                int firstWordCount = outputString.IndexOf('&', outputString.IndexOf('&') + 1) - outputString.IndexOf('&') - 1;
                ;
                int secondWordStartIndex = outputString.IndexOf('<') + 1;
                int secondWordCount = outputString.IndexOf('>') - outputString.IndexOf('<') - 1;


                string firstWord = outputString.Substring(firstWordStartIndex, firstWordCount);
                string secondWord = outputString.Substring(secondWordStartIndex, secondWordCount );

                Console.WriteLine($"Found {firstWord} at {secondWord}");

                keyCurrentIndex = 0;
            }

        }
    }
}
