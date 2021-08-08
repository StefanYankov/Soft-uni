namespace P08LettersChangeNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            // A12b s17G
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            double output = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                double tempOutput = 0.0;
                string current = input[i];
                char firstChar = current[0];
                char lastChar = current[current.Length - 1];
                double number = ExtractNumber(current);

                int firstLetterAlphabetIndex = char.ToUpper(firstChar) - 64;
                int secondLetterAlphabetIndex = char.ToUpper(lastChar) - 64;

                if (firstChar.Equals(Char.ToUpper(firstChar)))
                {
                    tempOutput += number * 1.0 / firstLetterAlphabetIndex * 1.0;
                }
                else
                {
                    tempOutput += number * firstLetterAlphabetIndex;
                }

                if (lastChar.Equals(Char.ToUpper(lastChar)))
                {
                    tempOutput -= secondLetterAlphabetIndex;
                }
                else
                {
                    tempOutput += secondLetterAlphabetIndex;
                }

                output += tempOutput;
            }

            Console.WriteLine($"{output:F2}");
        }

        private static double ExtractNumber(string current)
        {
            var resultString = Regex.Match(current, @"\d+").Value;

            return double.Parse(resultString);
        }
    }
}
