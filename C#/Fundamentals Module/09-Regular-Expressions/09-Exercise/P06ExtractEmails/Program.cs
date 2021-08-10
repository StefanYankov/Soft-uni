namespace P06ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"(^|(?<=\s))[A-Za-z\d]+([-._][A-Za-z\d]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+";

            string text = Console.ReadLine();

            MatchCollection validEmails = Regex.Matches(text, pattern);

            foreach (Match email in validEmails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
