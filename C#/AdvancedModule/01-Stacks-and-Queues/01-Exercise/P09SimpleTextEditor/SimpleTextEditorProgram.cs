namespace P09SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class SimpleTextEditorProgram
    {
        public static void Main()
        {
            Stack<string> stackOfText = new Stack<string>();
            StringBuilder text = new StringBuilder();
            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = input[0];

                if (command.Equals("1"))
                {
                    stackOfText.Push(text.ToString());
                    text.Append(input[1]);

                }
                else if (command.Equals("2"))
                {
                    int index = int.Parse(input[1]);
                    stackOfText.Push(text.ToString());
                    text.Remove(text.Length - index, index);
                }
                else if (command.Equals("3"))
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command.Equals("4"))
                {
                    text.Clear();
                    text.Append(stackOfText.Pop());
                }
            }
        }
    }
}
