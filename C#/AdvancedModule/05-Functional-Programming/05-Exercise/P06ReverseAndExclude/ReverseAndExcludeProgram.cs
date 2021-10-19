namespace P06ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ReverseAndExcludeProgram
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            Predicate<int> divisible = x => x % number != 0;
            Func<List<int>, List<int>> reverse = x =>
            {
                var temp = new List<int>();

                for (int i = x.Count - 1; i >= 0; i--)
                {
                    temp.Add(x[i]);
                }
                return x = temp.ToList();
            };

            Console.WriteLine(string.Join(" ", reverse(numbers).Where(x => divisible(x))));
        }
    }
}
