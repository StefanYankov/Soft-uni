using System;
using System.Globalization;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); // 18-04-2016

            DateTime dateTime = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(dateTime.DayOfWeek);
        }
    }
}
