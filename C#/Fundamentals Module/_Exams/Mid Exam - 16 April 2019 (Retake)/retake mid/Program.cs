using System;

namespace retake_mid
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEggs = priceFlour * 0.75;
            double priceMilk = (priceFlour * 1.25) / 4;

            double cozonacsCost = priceFlour + priceEggs + priceMilk;
            int cozonacsCount = 0;
            int eggsCount = 0;

            while (budget > cozonacsCost)
            {
                budget -= cozonacsCost;
                eggsCount += 3;
                cozonacsCount++;
                if (cozonacsCount % 3 == 0)
                {
                    eggsCount = eggsCount - (cozonacsCount - 2);
                }
            }

            Console.WriteLine($"You made {cozonacsCount} cozonacs! Now you have {eggsCount} eggs and {budget:f2}BGN left.");

        }
    }
}
