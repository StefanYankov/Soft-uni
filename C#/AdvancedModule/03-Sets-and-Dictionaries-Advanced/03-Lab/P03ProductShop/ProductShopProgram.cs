namespace P03ProductShop
{
    using System;
    using System.Collections.Generic;
    public class ProductShopProgram
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>>
                shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                if (command.Equals("Revision"))
                {
                    break;
                }

                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(command))
                {
                    shops.Add(command, new Dictionary<string, double>());
                }

                if (!shops[command].ContainsKey(product))
                {
                    shops[command].Add(product, 0);
                }
                shops[command][product] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
