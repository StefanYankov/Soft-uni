namespace P02SumNumbers
{
    using System;
    using System.Linq;
    public class SumNumbersProgram
    {
        public static void Main()
        {
            
            var input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            /* option 2
            string input = Console.ReadLine();
            Func<string, int> parser = x => int.Parse(x);
            int[] numbers = input.Split(',',StringSplitOptions.RemoveEmptyEntries)
                       .Select(parser).ToArray();
            */
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
