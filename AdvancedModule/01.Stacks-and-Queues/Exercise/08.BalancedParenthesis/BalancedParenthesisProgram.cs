using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main()
        {
            char[] parenthesis = Console.ReadLine()
                .ToCharArray();
            Stack<char> stackOfParenthesis = new Stack<char>();

            char[] openParenthesis = new char[] { '(', '{', '['};

            bool isValid = true;

            foreach (char item in parenthesis)
            {
                if (openParenthesis.Contains(item))
                {
                    stackOfParenthesis.Push(item);
                    continue;
                }

                if (stackOfParenthesis.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParenthesis.Peek() == '(' && item == ')')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '{' && item == '}')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '[' && item == ']')
                {
                    stackOfParenthesis.Pop();
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
