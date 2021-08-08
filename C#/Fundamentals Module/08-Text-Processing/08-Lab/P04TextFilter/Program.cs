namespace P04TextFilter
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string[] wordsToRemove = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var wordToRemove in wordsToRemove)
            {
                string newString = new string('*', wordToRemove.Length);
                text = text.Replace(wordToRemove, newString);
            }

            Console.WriteLine(text);
        }
    }
}
