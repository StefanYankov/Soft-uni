namespace P01MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {

            string pattern = @"(\b[A-Z][a-z]+) (\b[A-Z][a-z]+\b)";
            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match name in matches)
            {
                Console.Write(name.Value.Trim() + " ");
            }
            Console.WriteLine();
        }
    }
}
