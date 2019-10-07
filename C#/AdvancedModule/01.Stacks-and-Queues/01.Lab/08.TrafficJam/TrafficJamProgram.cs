using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main()
        {
            int carsToPass = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Queue<string> traffic = new Queue<string>();

            int counter = 0;

            while (command != "end")
            {
                if (command == "green")
                {

                    int currentCount = traffic.Count > carsToPass ? carsToPass : traffic.Count;
                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine($"{traffic.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    traffic.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
