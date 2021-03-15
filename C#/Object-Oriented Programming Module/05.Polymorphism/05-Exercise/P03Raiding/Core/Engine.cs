using P03Raiding.Core.Contracts;
using P03Raiding.Factory;
using P03Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<BaseHero> raidGroup;
        public Engine()
        {
            raidGroup = new List<BaseHero>();
        }
        public void Run()
        {

            int raidGroupSize = int.Parse(Console.ReadLine());
            int counter = 0;
            while (raidGroupSize != counter)
            {
                string currentHeroName = Console.ReadLine();
                string currentHeroClass = Console.ReadLine();

                try
                {
                    BaseHero hero = FactoryHeroes.CreateHero(currentHeroClass, currentHeroName);
                    raidGroup.Add(hero);
                    counter++;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            double bossPower = double.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sum = raidGroup.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
