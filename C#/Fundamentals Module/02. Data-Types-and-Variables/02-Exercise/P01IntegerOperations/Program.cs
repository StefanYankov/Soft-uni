namespace P01IntegerOperations
{
    using System;
    public class Program
    {
        public static void Main()
        {
            long number1 = long.Parse(Console.ReadLine());
            long number2 = long.Parse(Console.ReadLine());
            long number3 = long.Parse(Console.ReadLine());
            long number4 = long.Parse(Console.ReadLine());

            long result = ((number1 + number2) / number3) * number4;
            Console.WriteLine(result);
        }
    }
}
