namespace P07ConcatNames
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimeter}{secondName}");
        }
    }
}
