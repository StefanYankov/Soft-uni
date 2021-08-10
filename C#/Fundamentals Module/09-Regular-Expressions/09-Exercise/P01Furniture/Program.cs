using System.Text.RegularExpressions;

namespace P01Furniture
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string pattern =
                @"(?<leftDelimiter>[\>]{2})(?<furniture>\w+)(?<rightDelimiter>[\<]{2})(?<price>(0|[1-9]\d*)|(0|[1-9]\d*)(\.\d+))!(?<quantity>\d+)";
            List<string> furnitureRepository = new List<string>();
            double totalMoneySpend = 0;

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("Purchase"))
            {
                var furnitureMatch = Regex.Matches(input, pattern);

                foreach (Match furniture in furnitureMatch)
                {
                    string name = furniture.Groups["furniture"].Value;
                    furnitureRepository.Add(name);
                    double singlePrice = double.Parse(furniture.Groups["price"].Value);
                    int quantity = int.Parse(furniture.Groups["quantity"].Value);

                    totalMoneySpend += singlePrice * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            if (furnitureRepository.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, furnitureRepository));
            }
            Console.WriteLine($"Total money spend: {totalMoneySpend:F2}");

        }
    }
}
