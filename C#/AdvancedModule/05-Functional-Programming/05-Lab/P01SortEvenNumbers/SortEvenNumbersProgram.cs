namespace P01SortEvenNumbers
{
    using System;
    using System.Linq;
    public class SortEvenNumbersProgram
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ",input));
        }
    }
}
