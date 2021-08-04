namespace P01Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<int> wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command;
            while (!(command = Console.ReadLine()).Equals("end"))
            {
                if (command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0].Equals("Add"))
                {
                    int passengersCount = int.Parse(command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray()[1]);
                    wagons.Add(passengersCount);
                }
                else
                {
                    int passengersCount = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[0];
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + passengersCount) > maxCapacity)
                        {
                            continue;
                        }
                        wagons[i] += passengersCount;
                        break;
                    }
                }
            }
            Console.WriteLine(String.Join(' ', wagons));
        }
    }
}
