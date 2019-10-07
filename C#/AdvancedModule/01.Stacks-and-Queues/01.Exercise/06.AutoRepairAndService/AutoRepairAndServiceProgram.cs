using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.AutoRepairAndService
{
    class Program
    {
        static void Main()
        {
   
            var vehiclesForService = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string command = Console.ReadLine();

            Queue<string> carQueue = new Queue<string>(vehiclesForService);
            Stack<string> carServedHistory = new Stack<String>();

            while (command != "End")
            {

                if (command == "Service")
                {
                    if (carQueue.Count > 0)
                    {
                        carServedHistory.Push(carQueue.Peek());
                        Console.WriteLine($"Vehicle {carQueue.Dequeue()} got served.");
                    }
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", carServedHistory));
                }
                else
                {
                    var carInfo = command.Split("-").ToArray();
                    string carToCheck = carInfo[1];
                    if (carQueue.Contains(carInfo[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                command = Console.ReadLine();
            }
            if (carQueue.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carQueue)}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ", carServedHistory)}");

        }
    }
}
