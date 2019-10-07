using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmeticsProgram
    {
        static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> incrementByOne = x => x += 1;
            Func<int, int> multiplyByTwo = x => x *= 2;
            Func<int, int> subtractByOne = x => x -= 1;
            Action<int[]> print = numbers =>
            Console.WriteLine(string.Join(" ", numbers));

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    inputNumbers = inputNumbers.Select(incrementByOne).ToArray();
                }
                else if (command == "multiply")
                {
                    inputNumbers = inputNumbers.Select(multiplyByTwo).ToArray();
                }
                else if (command == "subtract")
                {
                    inputNumbers = inputNumbers.Select(subtractByOne).ToArray();
                }
                else if (command == "print")
                {
                    print(inputNumbers);
                }
                command = Console.ReadLine();
            }
        }
    }
}
