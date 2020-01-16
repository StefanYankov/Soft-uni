using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.Name = pokemonName;
            this.Element = pokemonElement;
            this.Health = pokemonHealth;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }
}
