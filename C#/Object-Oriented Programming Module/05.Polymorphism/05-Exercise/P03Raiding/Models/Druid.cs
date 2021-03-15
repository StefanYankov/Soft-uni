﻿namespace P03Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80; 
        public Druid(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {DefaultPower}";
        }
    }
}
