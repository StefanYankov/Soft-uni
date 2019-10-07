using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharPrint(firstChar, secondChar);
        }

        private static void CharPrint(char firstChar, char secondChar)
        {
            if (secondChar<firstChar)
            {
                char temp = firstChar;
                firstChar = secondChar;
                secondChar = temp;

            }
            for (char i = (char)(firstChar + 1); i < secondChar; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
