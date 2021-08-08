using System.Collections.Generic;
using System.Text;

namespace P06ReplaceRepeatingChars
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                return;
            }
            char[] characters = input.ToCharArray();
            List<char> charList = new List<char>(characters);
            StringBuilder output = new StringBuilder();
            output.Append(charList[0]);

            for (int i = 1; i < charList.Count; i++)
            {
                if (charList[i] == charList[i-1])
                {
                    continue;
                }

                output.Append(charList[i]);
            }

            Console.WriteLine(output.ToString());
        }
    }
}
