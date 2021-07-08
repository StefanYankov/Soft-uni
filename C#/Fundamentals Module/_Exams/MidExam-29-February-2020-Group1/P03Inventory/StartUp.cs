using System;
using System.Linq;
using System.Collections.Generic;

namespace P03Inventory
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input;

            while (!((input = Console.ReadLine()).Equals("Craft!")))
            {
                string command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[0];
                string item = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1];

                switch (command)
                {
                    case "Collect":
                        if (items.Contains(item))
                        {
                            continue;
                        }
                        items.Add(item);
                        break;
                    case "Drop":
                        if (items.Contains(item))
                        {
                            items.Remove(item);
                        }
                        break;
                    case "Combine Items":
                        string oldItem = item.Split(':', StringSplitOptions.RemoveEmptyEntries)[0];
                        if (items.Contains(oldItem))
                        {
                            string newItem = item.Split(':', StringSplitOptions.RemoveEmptyEntries)[1];
                            int index = items.IndexOf(oldItem);
                            items.Insert(index + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (items.Contains(item))
                        {
                            items.Remove(item);
                            items.Add(item);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", items));
        }
    }
}
