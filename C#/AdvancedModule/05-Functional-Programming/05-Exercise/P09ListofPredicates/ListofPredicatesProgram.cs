namespace P09ListofPredicates
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class ListofPredicatesProgram
    {
        public static void Main()
        {
            int end = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var numbers = Enumerable.Range(1, end);

            Func<int, int, bool> filter = (x, y) => x % y == 0;
            bool isDivisible = true;
            var result = new List<int>();

            for (int i = 1; i <= numbers.Count(); i++)
            {
                for (int j = 0; j < divisors.Length; j++)
                {
                    if (!filter(i, divisors[j]))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    result.Add(i);
                }
                isDivisible = true;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
