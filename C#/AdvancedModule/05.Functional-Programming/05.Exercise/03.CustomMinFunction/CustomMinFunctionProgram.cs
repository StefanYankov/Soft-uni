namespace P03CustomMinFunction
{
    using System;
    using System.Linq;
    public class CustomMinFunctionProgram
    {
        public static void Main()
        {
            Action<int> printNumber = x => Console.WriteLine(x);

            Func<IEnumerable<int>, int> minFunction = numbers =>
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

            var inputNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            int minNumber = minFunction(inputNumber);
            printNumber(minNumber);
        }
    }
}
