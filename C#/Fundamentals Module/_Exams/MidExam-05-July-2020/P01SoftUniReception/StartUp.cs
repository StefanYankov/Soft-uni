using System;

namespace P01SoftUniReception
{
    public class StartUp
    {
        public static void Main()
        {
            int bandwithEmployee1 = int.Parse(Console.ReadLine());
            int bandwithEmployee2 = int.Parse(Console.ReadLine());
            int bandwithEmployee3 = int.Parse(Console.ReadLine());

            int studentCount = int.Parse(Console.ReadLine());

            int hourCounter = 0;

            // Every forth hour all of the employees have a break, so they don’t work for a hour. 

            while (studentCount > 0)
            {
                hourCounter++;
                if (hourCounter % 4 == 0)
                {
                    continue;
                }

                int totalBandwith = bandwithEmployee1 + bandwithEmployee2 + bandwithEmployee3;
                studentCount -= totalBandwith;
            }

            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}
