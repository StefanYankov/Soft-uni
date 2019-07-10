﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxAndMinElement
{
    class Program
    {
        static void Main()
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= numberOfQueries; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }

                }
                else if (command[0] == 4)
                {
                    if (stack.Count >0)
                    {
                        Console.WriteLine(stack.Min());
                    }

                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
