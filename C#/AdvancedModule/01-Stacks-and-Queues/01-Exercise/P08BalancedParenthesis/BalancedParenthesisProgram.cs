namespace P08BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BalancedParenthesisProgram
    {
        public static void Main()
        {
            // {{[[(())]]}}
            char[] parentheses = Console.ReadLine()
                .ToCharArray();
            Stack<char> stackOfParentheses = new Stack<char>();

            char[] openParenthesis = new char[] { '(', '{', '[' };

            bool isValid = true;

            foreach (char parenthesis in parentheses)
            {
                if (openParenthesis.Contains(parenthesis))
                {
                    stackOfParentheses.Push(parenthesis);
                    continue;
                }

                if (stackOfParentheses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParentheses.Peek().Equals('(') && parenthesis.Equals(')'))
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek().Equals('{') && parenthesis.Equals('}'))
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek().Equals('[') && parenthesis.Equals(']'))
                {
                    stackOfParentheses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
