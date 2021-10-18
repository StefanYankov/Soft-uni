namespace P02SumNumbers
{
    using System;
    using System.Linq;
    public class SumNumbersProgram
    {
        public static void Main()
        {
            // Option #1
            var input = Console.ReadLine().Split(", ").Select(intParser);
            // Option #2
            //var input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            /* Option 3
            string input = Console.ReadLine();
            Func<string, int> parser = x => int.Parse(x);
            int[] numbers = input.Split(',',StringSplitOptions.RemoveEmptyEntries)
                       .Select(parser).ToArray();
            */
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
        
        static int intParser(string numberAsString)
        {
            int number = 0;
            foreach (var digit in numberAsString)
            {
                number *= 10;
                number += (digit - '0');
            }

            return number;
        }
    }
}
