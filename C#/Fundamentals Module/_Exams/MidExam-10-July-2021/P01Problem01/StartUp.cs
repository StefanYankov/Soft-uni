using System;

namespace P01Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfOrders = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 1; i <= numberOfOrders; i++)
            {
                double pricePerCapsulse = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double orderPrice = (days * capsuleCount) * pricePerCapsulse;
                totalPrice += orderPrice;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:F2}");

            }

            Console.WriteLine($"Total: ${totalPrice:F2}");


        }
    }
}
