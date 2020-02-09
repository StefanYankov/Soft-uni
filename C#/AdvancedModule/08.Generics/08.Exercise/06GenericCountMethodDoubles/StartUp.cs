using System;

namespace _06GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main()
        {
            int counter = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < counter; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Values.Add(input);
            }

            double targetItem = double.Parse(Console.ReadLine());

            int result = box.GreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}