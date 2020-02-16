using System;

namespace _03Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> myCustomStack = new CustomStack<int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Push")
                {
                    for (int currentNumber = 1; currentNumber < tokens.Length; currentNumber++)
                    {
                        myCustomStack.Push(int.Parse(tokens[currentNumber]));
                    }
                }
                else if (command == "Pop")
                {
                    myCustomStack.Pop();
                }
            }

            foreach (var number in myCustomStack)
            {
                Console.WriteLine(number);
            }

            foreach (var number in myCustomStack)
            {
                Console.WriteLine(number);
            }
        }
    }
}