using System;
using System.Text;

namespace P01ComputerStore
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            double totalPriceWithoutTaxes = 0;
            while (!(input.Equals("special") || input.Equals("regular")))
            {
                double price = double.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                totalPriceWithoutTaxes += price;
                input = Console.ReadLine();
            }

            if (totalPriceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = totalPriceWithoutTaxes * 0.20;
            double totalPrice = totalPriceWithoutTaxes + taxes;

            if (input.Equals("special"))
            {
                totalPrice -= totalPrice * 0.10;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Congratulations you've just bought a new computer!");
            sb.AppendLine($"Price without taxes: {totalPriceWithoutTaxes:F2}$");
            sb.AppendLine($"Taxes: {taxes:F2}$");
            sb.AppendLine($"-----------");
            sb.AppendLine($"Total price: {totalPrice:F2}$");

            Console.WriteLine(sb.ToString());
        }
    }
}
