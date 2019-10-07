using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input != "END")
            {
                IsPalindrome(input);

                input = Console.ReadLine();
            }
        }

        private static void IsPalindrome(string input)
        {
            string reversed = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }

            if (reversed != input)
            {
                Console.WriteLine("false");
            }
            else if (reversed == input)
            {
                Console.WriteLine("true");
            }

            //Before: reversed is not empty
            reversed = string.Empty;
            //After: reversed is empty
        }
    }
}
