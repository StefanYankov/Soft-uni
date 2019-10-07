using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            var productPrice = new Dictionary<string, double>();
            var productQuantity = new Dictionary<string, int>();

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!productPrice.ContainsKey(product) || !productQuantity.ContainsKey(product))
                {
                    productQuantity.Add(product, quantity);
                    productPrice.Add(product, price);
                }
                else
                {
                    productQuantity[product] += quantity;
                    if (productPrice[product] != price)
                    {
                        productPrice[product] = price;
                    }

                }

                input = Console.ReadLine().Split().ToArray();
            }

            foreach (var kvp in productPrice)
            {
                string productName = kvp.Key;
                double totalPrice = kvp.Value * productQuantity[productName];

                Console.WriteLine($"{productName} -> {totalPrice:f2}");
            }


        }
    }
}