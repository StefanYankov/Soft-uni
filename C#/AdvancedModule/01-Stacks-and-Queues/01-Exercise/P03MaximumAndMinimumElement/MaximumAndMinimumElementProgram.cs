namespace P03MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MaximumAndMinimumElementProgram
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int numberOfQueries = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfQueries; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                switch (command)
                {
                    case "1":
                        int elementToPush = int.Parse(input[1]);
                        stack.Push(elementToPush);
                        break;
                    case "2": // Delete
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case "3": //MaxElement
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case "4": // MinElement
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}
