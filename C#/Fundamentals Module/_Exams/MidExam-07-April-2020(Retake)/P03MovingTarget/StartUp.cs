using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MovingTarget
{
    public class StartUp
    {
        public static void Main()
        {
            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input;
            int index;
            int secondaryValue;
            string command;
            while (!((input = Console.ReadLine()).Equals("End")))
            {
                command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                index = int.Parse(input.Split(' ')[1]);
                secondaryValue = int.Parse(input.Split(' ')[2]);

                switch (command)
                {
                    case "Shoot":
                        if (index < 0 || index >= targets.Count)
                        {
                            continue;
                        }
                        targets[index] -= secondaryValue;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }

                        break;
                    case "Add":
                        if (index < 0 || index >= targets.Count)
                        {
                            Console.WriteLine("Invalid placement!");
                            continue;
                        }

                        targets.Insert(index, secondaryValue);
                        break;
                    case "Strike":
                        if (index < 0 || index >= targets.Count)
                        {
                            continue;
                        }

                        if ((index + secondaryValue >= targets.Count) || (index - secondaryValue < 0))
                        {
                            Console.WriteLine("Strike missed!");
                            continue;
                        }

                        targets.RemoveRange((index - secondaryValue), secondaryValue * 2 + 1);

                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join('|', targets));
        }
    }
}
