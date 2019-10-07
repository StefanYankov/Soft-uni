using System;
using System.Collections.Generic;

namespace _01.ClubParty
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int maxCapacity = int.Parse(Console.ReadLine());

            string[] inputLine = Console.ReadLine().Split();
            Stack<string> elements = new Stack<string>(inputLine);
            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();

            int currentCapacity = 0;

            while (elements.Count > 0)
            {
                string currentElement = elements.Pop();

                bool isNumber = int.TryParse(currentElement, out int parsedNumber);

                if (!isNumber)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity + parsedNumber > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count > 0)
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }

                }
            }

        }

    }
}
