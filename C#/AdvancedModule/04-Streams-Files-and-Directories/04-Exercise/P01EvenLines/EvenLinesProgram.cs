namespace P01EvenLines
{
    using System.IO;
    using System.Linq;
    using System;
    public class EvenLinesProgram
    {
        public static void Main()
        {
            using StreamReader sr = new StreamReader(@"files\text.txt"); // text.txt has "always copy"
            char[] specialSymbols = {'-', ',', '.', '!', '?'};
            int counter = -1;
            while (true)
            {
                counter++;
                string result = sr.ReadLine();
                if (result == null)
                {
                    break;
                }

                if (counter % 2 != 0)
                {
                    continue;
                }

                foreach (var symbol in specialSymbols)
                {
                    result = result.Replace(symbol, '@');
                }
                Console.WriteLine(string.Join(" ",result.Split().Reverse()));
            }
        }
    }
}
