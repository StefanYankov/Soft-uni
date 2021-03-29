using System;

namespace P01SquareRoot
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException();
                }

                double numberRoot = Math.Sqrt(number);
                Console.WriteLine($"The square root of {number} is {numberRoot:F2}");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
