using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Problem02
{
    public class StartUp
    {
        public static void Main()
        {
            List<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input;

            while (!((input = Console.ReadLine()).Equals("Finish")))
            {
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                int value = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                switch (command)
                {
                    case "Add":
                        sequence.Add(value);
                        break;
                    case "Remove":
                        if (!sequence.Contains(value))
                        {
                            continue;
                        }
                        sequence.Remove(value); // might need another command
                        break;
                    case "Replace":
                        if (!sequence.Contains(value))
                        {
                            continue;
                        }
                        int replacement = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                        int index = sequence.IndexOf(value);
                        sequence.Remove(value);
                        sequence.Insert(index, replacement);
                        break;
                    case "Collapse":
                        sequence.RemoveAll(x => x < value);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(String.Join(' ', sequence));

        }
    }
}
