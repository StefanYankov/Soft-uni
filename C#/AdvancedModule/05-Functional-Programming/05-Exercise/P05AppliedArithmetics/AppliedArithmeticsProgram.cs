namespace P05AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmeticsProgram
    {
        public static void Main()
        {
            Func<List<int>, List<int>> add = x => x.Select(y => y + 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(y => y * 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(y => y - 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            List<int> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("end"))
                {
                    break;
                }

                if (command.Equals("add"))
                {
                    input = add(input);

                }
                else if (command.Equals("multiply"))
                {
                    input = multiply(input);
                }
                else if (command.Equals("subtract"))
                {
                    input = subtract(input);
                }
                else if (command.Equals("print"))
                {
                    print(input);
                }
            }
        }
    }
}
