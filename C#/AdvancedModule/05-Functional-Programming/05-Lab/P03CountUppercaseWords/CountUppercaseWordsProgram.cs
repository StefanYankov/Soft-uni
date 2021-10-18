namespace P03CountUppercaseWords
{
    using System;
    using System.Linq;
    public class CountUppercaseWordsProgram
    {
        public static void Main()
        {
            Func<string, bool> checker = w => w[0] == w.ToUpper()[0];
            var words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Where(checker)
                               .ToArray();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
