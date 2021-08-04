namespace P04ListOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> operationsList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = string.Empty;


            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();
                string action = commands[0];
                if (action == "Add")
                {
                    int task = int.Parse(commands[1]);
                    operationsList.Add(task);
                }
                else if (action == "Insert")
                {
                    int task = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    if (index >= 0 && index < operationsList.Count)
                    {
                        operationsList.Insert(index, task);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (action == "Shift")
                {
                    string direction = commands[1];
                    if (direction == "left")
                    {
                        int task = int.Parse(commands[2]);
                        while (task != 0)
                        {
                            int currentnumber = operationsList[0];
                            operationsList.RemoveAt(0);
                            operationsList.Add(currentnumber);
                            task--;
                        }
                    }
                    else if (direction == "right")
                    {
                        int task = int.Parse(commands[2]);
                        while (task != 0)
                        {
                            int currentnumber = operationsList[operationsList.Count - 1];
                            operationsList.RemoveAt(operationsList.Count - 1);
                            operationsList.Insert(0, currentnumber);
                            task--;
                        }
                    }
                }
                else if (action == "Remove")
                {
                    int task = int.Parse(commands[1]);
                    if (task >= 0 && task < operationsList.Count)
                    {
                        operationsList.RemoveAt(task);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
            }

            Console.WriteLine(String.Join(" ", operationsList));
        }
    }
}