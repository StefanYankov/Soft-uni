namespace P03HeroesOfCodeAndLogicVII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            List<Hero> party = new List<Hero>();
            for (int i = 1; i <= numberOfHeroes; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = input[0];
                int hitPoints = int.Parse(input[1]);
                int manaPoints = int.Parse(input[2]);
                Hero hero = new Hero(name, hitPoints, manaPoints);
                party.Add(hero);
            }

            string commands = string.Empty;

            while (!(commands = Console.ReadLine()).Equals("End"))
            {
                string[] commandsArg = commands
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToArray();
                string heroName = commandsArg[1];
                Hero hero = party.FirstOrDefault(x => x.Name.Equals(heroName));
                int amount = 9;
                switch (commandsArg[0])
                {
                    case "CastSpell":
                        int neededMP = int.Parse(commandsArg[2]);
                        string spellName = commandsArg[3];
                        hero.CastASpell(neededMP, spellName);
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commandsArg[2]);
                        string attacker = commandsArg[3];
                        hero.TakeDamage(damage, attacker, ref party);
                        break;
                    case "Recharge":
                        amount = int.Parse(commandsArg[2]);
                        hero.Recharge(amount);
                        break;
                    case "Heal":
                        amount = int.Parse(commandsArg[2]);
                        hero.Heal(amount);
                        break;
                }
            }

            foreach (Hero hero in party.OrderByDescending(h => h.HitPoints).ThenBy(h => h.Name))
            {
                Console.WriteLine($"{hero.Name}{Environment.NewLine}HP: {hero.HitPoints}{Environment.NewLine}MP: {hero.ManaPoints}");
            }
        }
    }

    public class Hero
    {
        private const int MaxHitPoints = 100;
        private const int MaxManaPoints = 200;
        private int _hitPoints;
        private int _manaPoints;

        public Hero(string name, int hitPoints, int manaPoints)
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.ManaPoints = manaPoints;
        }

        public string Name { get; set; }
        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                if (value > MaxHitPoints)
                {
                    _hitPoints = MaxHitPoints;
                }
                else
                {
                    _hitPoints = value;
                }
            }
        }
        public int ManaPoints

        {
            get => _manaPoints;
            set
            {
                if (value > MaxManaPoints)
                {
                    _manaPoints = MaxManaPoints;
                }
                _manaPoints = value;
            }
        }
        public void CastASpell(int manaPoints, string spellName)
        {
            if ((this.ManaPoints - manaPoints) >= 0)
            {
                this.ManaPoints -= manaPoints;
                Console.WriteLine($"{this.Name} has successfully cast {spellName} and now has {this.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have enough MP to cast {spellName}!");
            }
        }
        public void TakeDamage(int damage, string attacker, ref List<Hero> party)
        {
            if ((this.HitPoints - damage) > 0)
            {
                this.HitPoints -= damage;
                Console.WriteLine($"{this.Name} was hit for {damage} HP by {attacker} and now has {this.HitPoints} HP left!");
            }
            else
            {
                party.Remove(this);
                Console.WriteLine($"{this.Name} has been killed by {attacker}!");
            }
        }
        public void Recharge(int amount)
        {
            if ((this.ManaPoints + amount) > MaxManaPoints)
            {
                Console.WriteLine($"{this.Name} recharged for {MaxManaPoints - this.ManaPoints} MP!");
                this.ManaPoints = MaxManaPoints;

            }
            else
            {
                Console.WriteLine($"{this.Name} recharged for {amount} MP!");
                this.ManaPoints += amount;
            }
        }
        public void Heal(int amount)
        {
            if ((this.HitPoints + amount) > MaxHitPoints)
            {
                Console.WriteLine($"{this.Name} healed for {MaxHitPoints - this.HitPoints} HP!");
                this.HitPoints = MaxHitPoints;
            }
            else
            {
                Console.WriteLine($"{this.Name} healed for {amount} HP!");
                this.HitPoints += amount;

            }
        }
    }
}