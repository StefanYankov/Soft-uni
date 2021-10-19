namespace P07PredicateForNames
{
    using System;
    using System.Linq;
    public class PredicateForNamesProgram
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> filter = x => x.Length <= length;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => filter(x))));
        }
    }
}
