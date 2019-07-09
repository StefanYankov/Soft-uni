using System;

namespace P03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;
            double discountedSum = 0;

            switch (groupType)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = 8.45;
                                break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    break;
                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16.00;
                            break;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            price = 15.00;
                            break;
                        case "Saturday":
                            price = 20.00;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                    }
                    break;
            }

            if (groupType == "Students" && groupCount >= 30)
            {
                discountedSum = (groupCount * price) * 0.85;
            }
            else if (groupType == "Business" && groupCount >= 100)
            {
                discountedSum = (groupCount - 10) * price;
            }
            else if (groupType == "Regular" && (groupCount >= 10 && groupCount <= 20))
            {
                discountedSum = (groupCount * price) * 0.95;
            }
            else
            {
                discountedSum = groupCount * price;
            }
            Console.WriteLine($"Total price: {discountedSum:F2}");
        }

        }
    }
