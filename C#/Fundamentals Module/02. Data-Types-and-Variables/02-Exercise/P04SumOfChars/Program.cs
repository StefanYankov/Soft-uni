namespace P04SumOfChars
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());
            int ASCIISum = 0;
            char inputChar;
            for (int i = 0; i < lineCount; i++)
            {
                inputChar = Console.ReadLine()[0];
                ASCIISum += (int)inputChar;
            }

            Console.WriteLine($"The sum equals: {ASCIISum}");
        }
    }
}
