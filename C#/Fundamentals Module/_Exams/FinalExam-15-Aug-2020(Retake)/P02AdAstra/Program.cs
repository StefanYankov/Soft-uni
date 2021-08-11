namespace P02AdAstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        private const int DailyCaloriesNeeded = 2000;

        public static void Main()
        {
            List<Food> items = new List<Food>();
            int totalCalories = 0;

            string pattern = @"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string foodName = match.Groups["name"].Value;
                string foodDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                Food food = new Food(foodName, foodDate, calories);
                items.Add(food);
            }

            totalCalories = items.Sum(x => x.Calories);
            int days = totalCalories / DailyCaloriesNeeded;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (var food in items)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.ExpirationDate}, Nutrition: {food.Calories}");
            }
        }

        public class Food
        {
            public Food(string name, string expirationDate, int calories)
            {
                this.Name = name;
                this.ExpirationDate = expirationDate;
                this.Calories = calories;
            }

            public string Name { get; set; }
            public string ExpirationDate { get; set; }
            public int Calories { get; set; }
        }
    }
}
