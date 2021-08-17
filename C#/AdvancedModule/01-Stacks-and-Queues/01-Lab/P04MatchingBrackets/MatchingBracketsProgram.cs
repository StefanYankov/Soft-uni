namespace P04MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char @char = input[i];
                if (@char.Equals('('))
                {
                    stack.Push(i);
                }
                else if (@char.Equals(')'))
                {
                    int leftIndex = stack.Pop();
                    string expression = input.Substring(leftIndex, i - leftIndex + 1);
                    Console.WriteLine(expression);
                }
            }
        }
    }
}
