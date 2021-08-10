namespace P05NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main()
        {
            string patternDemonHealth = @"(?<excludedChars>[^\d\-\+\*\/\.])";
            string patternNumbers = @"(?<number>\-?[0-9]\d*(\.\d+)?)";
            string patternModifiers = @"(?<modifiers>[\/\*])";

            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).ToArray();
            List<Demon> demons = new List<Demon>();
            for (int i = 0; i < input.Length; i++)
            {

                string name = input[i];
                int health = CalculateHealth(input[i], patternDemonHealth);
                double damage = CalculateDamage(input[i], patternNumbers, patternModifiers);
                Demon tempDemon = new Demon(name,health,damage);
                demons.Add(tempDemon);
            }

            foreach (var demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static double CalculateDamage(string demon, string patternNumbers, string patternModifiers)
        {
            double damage = 0;
            MatchCollection rawNumbers = Regex.Matches(demon, patternNumbers);
            var numbersArray = rawNumbers.Cast<Match>().Select(m => m.Value).Select(double.Parse).ToArray();
            damage += numbersArray.Sum();

            MatchCollection modifiers = Regex.Matches(demon, patternModifiers);

            foreach (Match modifier in modifiers)
            {
                if (modifier.Value.Equals("*"))
                {
                    damage *= 2.0;
                } 
                else if (modifier.Value.Equals("/"))
                {
                    damage /= 2.0;
                }
            }
            return damage;
        }

        private static int CalculateHealth(string demon, string patternNumbers)
        {
            int health = 0;
            MatchCollection charName = Regex.Matches(demon, patternNumbers);
            var matchArray = String.Join("",charName.Cast<Match>().Select(m => m.Value).ToArray());
            health += matchArray.Sum(x => x);
            return health;
        }
    }

    class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get; private set; }
        public int Health { get; private set; }
        public double Damage { get; private set; }
    }
}
