using System;
using System.Linq;

namespace _02._Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins = 100;
            int energy = 100;

            var arr = Console.ReadLine().Split("|").ToArray();

            for (int i = 0; i < arr.Length; i++)
            {

                var internalArr = arr[i].Split("-").ToArray();

                if (internalArr[0] == "rest")
                {
                    int restEnergy = int.Parse(internalArr[1]);
                    energy += restEnergy;

                    if (energy >= 100)
                    {
                        energy = 100;
                        Console.WriteLine("You gained 0 energy.");

                    }
                    else
                    {
                        Console.WriteLine($"You gained {internalArr[1]} energy.");
                    }
                    Console.WriteLine($"Current energy: {energy}.");

                }
                else if (internalArr[0] == "order")
                {
                    energy = energy - 30;

                    if (energy >= 0)
                    {
                        int additionalCoins = int.Parse(internalArr[1]);
                        coins += additionalCoins;
                        Console.WriteLine($"You earned {additionalCoins} coins.");
                    }
                    else
                    {
                        energy += 80;
                        Console.WriteLine("You had to rest!");
                        if (energy > 100)
                        {
                            energy = 100;
                        }
                    }

                }
                else
                {
                    string ingredient = internalArr[0];
                    int coinsCost = int.Parse(internalArr[1]);

                    if ((coins - coinsCost) > 0)
                    {
                        Console.WriteLine($"You bought {ingredient}.");
                        coins -= coinsCost;
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        return;

                    }
                }

            }
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
        }
    }
}
