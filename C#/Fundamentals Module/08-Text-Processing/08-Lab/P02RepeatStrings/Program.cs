namespace P02RepeatStrings
{
    using System;
    using System.Linq;
    using System.Text;


    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
