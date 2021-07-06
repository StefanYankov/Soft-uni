using System;

namespace P01NationalCourt
{
    public class StartUp
    {
        public static void Main()
        {
            int bandwithEmployee1 = int.Parse(Console.ReadLine());
            int bandwithEmployee2 = int.Parse(Console.ReadLine());
            int bandwithEmployee3 = int.Parse(Console.ReadLine());

            int peopleCount = int.Parse(Console.ReadLine());

            int hourCounter = 0;


            while (peopleCount > 0)
            {
                hourCounter++;
                if (hourCounter % 4 == 0)
                {
                    continue;
                }

                int totalBandwith = bandwithEmployee1 + bandwithEmployee2 + bandwithEmployee3;
                peopleCount -= totalBandwith;
            }

            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}
