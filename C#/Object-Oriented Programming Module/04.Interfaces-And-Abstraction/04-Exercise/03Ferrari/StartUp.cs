using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Ferrari ferrari = new Ferrari(input);
            Console.WriteLine(ferrari);
        }
    }
}
