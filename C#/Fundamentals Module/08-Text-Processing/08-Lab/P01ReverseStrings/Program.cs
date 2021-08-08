namespace P01ReverseStrings
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("end"))
            {


                Console.WriteLine($"{input} = {Reverse(input)}");
            }
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
