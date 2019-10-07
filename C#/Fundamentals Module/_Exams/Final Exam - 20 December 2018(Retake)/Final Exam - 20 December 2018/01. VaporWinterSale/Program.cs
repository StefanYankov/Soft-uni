using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> gamesAndPrices = new Dictionary<string, decimal>();
            Dictionary<string, string> gamesAndDlc = new Dictionary<string, string>();

            //WitHer 3-50, FullLife 3-60, WitHer 3:Blood and Beer, Cyberfunk 2077-120, League of Leg Ends-10, League of Leg Ends:DoaT
            var input = Console.ReadLine().Split(", ").ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                //WitHer 3:Blood and Beer
                if (input[i].Contains(":"))
                {
                    string[] tokensDlc = input[i].Split(":");
                    //WitHer 3
                    //Blood and Beer
                    string gameName = tokensDlc[0];
                    string dlc = tokensDlc[1];

                    if (gamesAndPrices.ContainsKey(gameName))
                    {
                        gamesAndDlc.Add(gameName,dlc);
                        decimal increasedPrice = gamesAndPrices[gameName] + (gamesAndPrices[gameName] * 0.20m);
                        gamesAndPrices[gameName] = increasedPrice;
                    }
                }
                else
                {   //WitHer 3-50
                    string[] tokensWithoutDlc = input[i].Split("-");
                    //withHer 3
                    //50

                    string gameName = tokensWithoutDlc[0];
                    decimal gamePrice = decimal.Parse(tokensWithoutDlc[1]);

                    gamesAndPrices.Add(gameName, gamePrice);
                }
            }

            var gamesAndLoweredPriceWithoutDlc = new Dictionary<string,decimal>();
            var gamesAndLoweredPriceWithDlc = new Dictionary<string,decimal>();

            foreach (var game in gamesAndPrices)
            {
                string gameName = game.Key;
                decimal price = game.Value;

                if (!gamesAndDlc.ContainsKey(gameName))
                {
                    decimal lowerdPrice = price - (price * 0.20m);
                    gamesAndLoweredPriceWithoutDlc.Add(gameName,lowerdPrice);
                }
                else
                {
                    decimal lowerdPrice = price - (price * 0.50m);
                    gamesAndLoweredPriceWithDlc.Add(gameName, lowerdPrice);
                }

            }

            foreach (var kvp in gamesAndLoweredPriceWithDlc
                .OrderBy(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} - {gamesAndDlc[kvp.Key]} - {kvp.Value:f2}");
            }

            foreach (var kvp in gamesAndLoweredPriceWithoutDlc.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value:f2}");
            }

        }
    }
}
