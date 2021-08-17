namespace P03SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> expression = new Stack<string>(input.Reverse());
            int result = 0;
            while (expression.Count > 0)
            {
                var element = expression.Pop();
                if (element == "+")
                {
                    var number = expression.Pop();
                    result += int.Parse(number);
                }
                else if (element == "-")
                {
                    var number = expression.Pop();
                    result -= int.Parse(number);
                }
                else
                {
                    result = int.Parse(element);
                }
            }
        }

    }
}
