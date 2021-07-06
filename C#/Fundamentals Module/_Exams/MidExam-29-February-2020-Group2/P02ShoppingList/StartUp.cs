using System;
using System.Linq;
using System.Collections.Generic;

namespace P02ShoppingList
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> shoppingList = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input;

            while(!((input=Console.ReadLine()).Equals("Go Shopping!")))
            {
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string item = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                switch (command)
                {
                    case "Urgent":
                        if (!shoppingList.Contains(item))
                        {
                            shoppingList.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (shoppingList.Contains(item))
                        {
                            int getIndex = shoppingList.FindIndex(x => x.Contains(item));
                            shoppingList.RemoveAt(getIndex);
                        }
                        break;
                    case "Correct":
                        string newItem = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];
                        if (shoppingList.Contains(item))
                        {
                            int getIndex = shoppingList.FindIndex(x => x.Contains(item));
                            shoppingList.RemoveAt(getIndex);
                            shoppingList.Insert(getIndex, newItem);
                        }
                        break;
                    case "Rearrange":
                        if (shoppingList.Contains(item))
                        {
                            int getIndex = shoppingList.FindIndex(x => x.Contains(item));
                            shoppingList.RemoveAt(getIndex);
                            shoppingList.Add(item);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", shoppingList));
        }
    }
}
