namespace P03Substring
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string wordToBeRemoved = Console.ReadLine().ToLower();
            string inputString = Console.ReadLine();

            while (inputString.Contains(wordToBeRemoved))
            {
                int startIndex = inputString.IndexOf(wordToBeRemoved);
                inputString = inputString.Remove(startIndex, wordToBeRemoved.Length);
            }
            Console.WriteLine(inputString);

        }

    }
}
