using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunctionProgram
    {
        static void Main()
        {
            Action<int> printNumber = x => Console.WriteLine(x);

            Func<int[], int> minFunction = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            int[] inputNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int minNumber = minFunction(inputNumber);
            printNumber(minNumber);
        }
    }
}
