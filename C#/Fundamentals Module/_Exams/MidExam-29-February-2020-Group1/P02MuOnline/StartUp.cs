using System;
using System.Linq;

namespace P02MuOnline
{
    public class StartUp
    {
        public static void Main()
        {
            int health = 100;
            int bitcoins = 0;
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                string command = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                int number = int.Parse(input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                if (command.Equals("potion"))
                {
                    if (health == 100)
                    {
                        continue;
                    }

                    bool isEnoughHealing = number + health > 100;
                    if (isEnoughHealing == false)
                    {
                        int healthPoint = number;
                        health += number;
                        Console.WriteLine($"You healed for {healthPoint} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        int difference = 100 - health;
                        health += difference;
                        Console.WriteLine($"You healed for {difference} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }

                }
                else if (command.Equals("chest"))
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    health -= number;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");


        }
    }
}
