using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class ProductShopProgram
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if (!shops.ContainsKey(input[0]))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, 0);
                }

                shops[shop][product] = price;

                input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product:{item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
