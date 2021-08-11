namespace P04Santa_sSecretHelper
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string pattern = @"@(?<name>[A-Za-z]+)[^@\\\-!:>]*!([G])!";
            List<string> children = new List<string>();

            while (!(input = Console.ReadLine()).Equals("end"))
            {
                var charArray = input.ToCharArray();

                for (int i = 0; i < charArray.Length; i++)
                {
                    charArray[i] = (char)(charArray[i] - key);
                }

                input = new string(charArray);
                MatchCollection matches = Regex.Matches(input, pattern);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        children.Add(match.Groups["name"].Value);
                    }
                }
            }

            foreach (var child in children)
            {
                Console.WriteLine(child);
            }
        }
    }
}
