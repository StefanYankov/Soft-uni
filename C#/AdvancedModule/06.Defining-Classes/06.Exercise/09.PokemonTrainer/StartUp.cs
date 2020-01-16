using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string[] commandInfo = Console.ReadLine()
                .Split()
                .ToArray();

            while (commandInfo[0] != "Tournament")
            {
                string trainerName = commandInfo[0];
                string pokemonName = commandInfo[1];
                string pokemonElement = commandInfo[2];
                int pokemonHealth = int.Parse(commandInfo[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                currentTrainer.Pokemon.Add(pokemon);

                commandInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
            }

            commandInfo = Console.ReadLine()
                .Split()
                .ToArray();

            while (commandInfo[0] != "End")
            {
                string element = commandInfo[0];

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemon.Any(p => p.Element == element))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemon)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.Pokemon.RemoveAll(x => x.Health <= 0);
                    }
                }

                commandInfo = Console.ReadLine()
                 .Split()
                 .ToArray();
            }

            var result = trainers
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.Badges} {item.Value.Pokemon.Count}");
            }
        }
    }
}
