using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {


            List<int> ingredientsValueList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).ToList();
            List<int> freshnessValueList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).ToList();


            Stack<int> stackOfFreshness = new Stack<int>(freshnessValueList);
            Queue<int> queueOfIngredients = new Queue<int>(ingredientsValueList);

            const int mimosa = 150;
            const int daiquiri = 250;
            const int sunshine = 300;
            const int mojito = 400;

            int mimosaCount = 0;
            int daiquiriCount = 0;
            int sunshineCount = 0;
            int mojitoCount = 0;

            while (queueOfIngredients.Count > 0 && stackOfFreshness.Count > 0)
            {
                int currentIngredient = queueOfIngredients.Peek();
                if (currentIngredient == 0)
                {
                    queueOfIngredients.Dequeue();
                        continue;
                }

                if (queueOfIngredients.Count == 0)
                {
                    break;
                }
                int currentFreshness = stackOfFreshness.Peek();
                int product = currentIngredient * currentFreshness;

                if (product == mimosa)
                {
                    mimosaCount++;
                    queueOfIngredients.Dequeue();
                    stackOfFreshness.Pop();
                }
                else if (product == daiquiri)
                {
                    daiquiriCount++;
                    queueOfIngredients.Dequeue();
                    stackOfFreshness.Pop();
                }
                else if (product == sunshine)
                {
                    sunshineCount++;
                    queueOfIngredients.Dequeue();
                    stackOfFreshness.Pop();
                }
                else if (product == mojito)
                {
                    mojitoCount++;
                    queueOfIngredients.Dequeue();
                    stackOfFreshness.Pop();
                }
                else
                {
                    int tempIngredient = currentIngredient + 5;
                    if (tempIngredient > 100)
                    {
                        tempIngredient = 100;
                    }
                    queueOfIngredients.Dequeue();
                    queueOfIngredients.Enqueue(tempIngredient);
                    stackOfFreshness.Pop();
                }

            }

            if (queueOfIngredients.Count == 0 && mimosaCount > 1 && daiquiriCount > 1 && sunshineCount > 1 && mojitoCount > 1)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
                Dictionary<string, int> print = new Dictionary<string, int>();
                if (mimosaCount > 0)
                {
                    print.Add("Mimosa", mimosaCount);
                }

                if (daiquiriCount > 0)
                {
                    print.Add("Daiquiri", daiquiriCount);
                }

                if (sunshineCount > 0)
                {
                    print.Add("Sunshine", sunshineCount);
                }

                if (mojitoCount > 0)
                {
                    print.Add("Mojito", mojitoCount);
                }

                foreach (var kvp in print.OrderBy(k => k.Key))
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (queueOfIngredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {queueOfIngredients.Sum()}");
                }

                Dictionary<string, int> print = new Dictionary<string, int>();
                if (mimosaCount > 0)
                {
                    print.Add("Mimosa", mimosaCount);
                }

                if (daiquiriCount > 0)
                {
                    print.Add("Daiquiri", daiquiriCount);
                }

                if (sunshineCount > 0)
                {
                    print.Add("Sunshine", sunshineCount);
                }

                if (mojitoCount > 0)
                {
                    print.Add("Mojito", mojitoCount);
                }

                if (print.Count > 0)
                {
                    foreach (var kvp in print.OrderBy(k => k.Key[0]))
                    {
                        Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                    }
                }
            }
        }
    }
}
