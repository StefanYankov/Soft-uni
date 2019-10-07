using System;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var replaceString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string result = "";

            Regex regex = new Regex(@"[d-z#|{}]+");
            var match = regex.Match(input);

            if (input.Length != match.Length)
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            else
            {
                for (int i = 0; i < match.Length; i++)
                {
                    result += ((char)(input[i] - 3));
                }
            }

            while (result.Contains(replaceString[0]))
            {
                result = result.Replace(replaceString[0], replaceString[1]);
            }
            Console.WriteLine(result);
        }
    }
}
