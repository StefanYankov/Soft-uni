using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            this.Name = trainerName;
            this.Badges = 0;
            this.Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemon { get; set; }
    }
}
