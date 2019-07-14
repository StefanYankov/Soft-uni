using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main()
        {
            Stack<string> stackOfText= new Stack<string>();
            StringBuilder text = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = input[0];

                if (command == "1")
                {
                    stackOfText.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (command == "2")
                {
                    int index = int.Parse(input[1]);
                    stackOfText.Push(text.ToString());
                    text.Remove(text.Length - index, index);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    text.Clear();
                    text.Append(stackOfText.Pop());
                }
            }
            
        }
    }
}
