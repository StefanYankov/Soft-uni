namespace P03HouseParty
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int countOfPeopleGoing = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            string[] input;
            for (int i = 1; i <= countOfPeopleGoing; i++)
            {
                input = Console.ReadLine().Split(" is ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];

                if (input[1].Equals("going!"))
                {
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(name);
                    }
                }
                else
                {
                    if (!guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        guestList.Remove(name);
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, guestList));
        }
    }
}
