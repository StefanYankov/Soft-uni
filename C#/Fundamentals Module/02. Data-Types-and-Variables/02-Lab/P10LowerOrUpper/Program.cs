namespace P10LowerOrUpper
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string character = Console.ReadLine();

            if (character == character.ToUpper())
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
