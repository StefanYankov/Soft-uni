using System;
using System.Linq;

namespace _5._Digits__Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToArray();
            string digits = string.Empty;
            string letters = string.Empty;
            string chars = string.Empty;

            foreach (var item in text)
            {
                if (char.IsDigit(item))
                {
                    digits += item;
                }
                else if (char.IsLetter(item))
                {
                    letters += item;
                }
                else
                {
                    chars += item;
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(chars);

        }
    }
}
