using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main()
        {
            string expr = Console.ReadLine(); // 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    stack.Push(i);

                }
                else if (expr[i] == ')')
                {
                    int startingIndex = stack.Pop();
                    Console.WriteLine(expr.Substring(startingIndex, i - startingIndex + 1));
                }
            }
        }
    }
}
