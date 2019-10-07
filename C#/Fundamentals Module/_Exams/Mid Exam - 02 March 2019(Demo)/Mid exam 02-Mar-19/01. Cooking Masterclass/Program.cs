using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine()); // 1 package of flour, 10 eggs and an apron. 
            double priceFlour = double.Parse(Console.ReadLine()); //every fifth package of flour is free. 
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine()); //buy 20% more, rounded up 
            double costFlour = 0;
            double costEgg = 10 * priceEgg * students;
            double costApron = priceApron * Math.Ceiling((students + (students*0.20)));

            int flourDiscountCounter = 0;

            if (students % 5 == 0)
            {
                for (int i = 1; i <= students; i+=5)
                {
                    flourDiscountCounter++;
                }

                costFlour = (students - flourDiscountCounter) * priceFlour;
            }
            else
            {
                costFlour = students * priceFlour;
            }

            double totalCost = costFlour + costEgg + costApron;

            if (budget >= totalCost)
            {
                Console.WriteLine($"Items purchased for {totalCost:f2}$.");
            }
            else
            {
                double diff = totalCost - budget;
                Console.WriteLine($"{diff:f2}$ more needed.");
            }
        }
    }
}
