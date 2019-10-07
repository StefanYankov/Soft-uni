using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            Queue<string> customers = new Queue<string>();

            while (command != "End")
            {
                if (command != "Paid")
                {
                    customers.Enqueue(command);
                }
                else
                {
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                    customers.Clear();
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
