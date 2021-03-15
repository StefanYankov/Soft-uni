﻿namespace P03Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int DefaultPower = 100;
        public Paladin(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {DefaultPower}";
        }
    }
}
