namespace P05PrintPartOfASCIITable
{
    using System;
    using System.Text;
    public class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();

            int startingIndex = int.Parse(Console.ReadLine());
            int endingIndex = int.Parse(Console.ReadLine());

            for (int i = startingIndex; i <= endingIndex; i++)
            {
                char currentChar = (char)i;
                sb.Append($"{currentChar} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
