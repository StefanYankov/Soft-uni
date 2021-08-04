using System;

namespace P09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int restYield = 0;

            while (startingYield >= 100)
            {
                days++;
                restYield += startingYield - 26;
                startingYield -= 10;
            }

            if (startingYield < 100 && days == 0)
            {

                Console.WriteLine(days);
                Console.WriteLine(restYield);
            }
            else
            {
                restYield -= 26;
                Console.WriteLine(days);
                Console.WriteLine(restYield);
            }
        }
    }
}
