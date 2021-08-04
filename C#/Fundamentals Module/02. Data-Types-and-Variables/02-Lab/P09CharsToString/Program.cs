namespace P09CharsToString
{
    using System;
    public class Program
    {
        public static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            string combinedChar = "" + firstChar + secondChar + thirdChar;
            Console.WriteLine(combinedChar);
        }
    }
}
