﻿using System;

namespace P10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double monitorPrice = double.Parse(Console.ReadLine());

            double money = 0;

        for (int i = 1; i <= lostGames; i++)
			{
                if (i % 12 == 0)
                {
                    money += monitorPrice;
                }

            if (i % 6 == 0)
                {
                    money += keyboardPrice;
                }
             if (i % 2 == 0)
                {
                    money += headsetPrice;
                }
            if (i % 3 == 0)
                {
                    money += mousePrice;
                }


			}
            Console.WriteLine($"Rage expenses: {money:f2} lv.");
            }
        }
}
