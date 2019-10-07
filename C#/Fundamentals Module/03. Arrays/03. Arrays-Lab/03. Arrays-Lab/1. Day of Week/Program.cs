using System;

namespace _1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            if (input > 0 && input <= 7)
            {
                Console.WriteLine(days[input-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
