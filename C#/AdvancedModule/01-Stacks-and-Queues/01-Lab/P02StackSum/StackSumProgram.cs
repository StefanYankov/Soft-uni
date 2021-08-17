namespace P02StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int[] intArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(intArray);
            string input = string.Empty;
            while (!(input = Console.ReadLine().ToLower()).Equals("end"))
            {
                string[] commandArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArray[0];

                if (command.ToLower().Equals("add"))
                {
                    int firstNumber = int.Parse(commandArray[1]);
                    int secondNumber = int.Parse(commandArray[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command.ToLower().Equals("remove"))
                {
                    int count = int.Parse(commandArray[1]);
                    if (stack.Count < count)
                    {
                        continue;
                    }

                    if (stack.Count == count)
                    {
                        stack.Clear();
                    }
                    else
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
