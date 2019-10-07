using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _8._Match_a_Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string regex = @"[+]359([ -])2\1\d{3}\1\d{4}\b";
            List<string> phones= new List<string>();

            MatchCollection matches = Regex.Matches(numbers, regex);

            foreach (Match number in matches)
            {
                phones.Add(number.Value);
            }
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
