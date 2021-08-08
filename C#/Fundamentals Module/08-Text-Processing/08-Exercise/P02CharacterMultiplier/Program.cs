namespace P02CharacterMultiplier
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long output = CharSum(input[0], input[1]);
            Console.WriteLine(output);
        }

        private static long CharSum(string str1, string str2)
        {
            long output = 0;
            int firstChar = 0;
            int secondChar = 0;
            if (str1.Length >= str2.Length) 
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    firstChar = (int)str1[i];
                    secondChar = (int)str2[i];
                    output += firstChar * secondChar;

                }

                for (int i = str2.Length; i < str1.Length; i++)
                {
                    output += (int)str1[i];
                }
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    firstChar = (int)str2[i];
                    secondChar = (int)str1[i];
                    output += firstChar * secondChar;

                }

                for (int i = str1.Length; i < str2.Length; i++)
                {
                    output += (int)str2[i];
                }
            }

            return output;
        }
    }
}
