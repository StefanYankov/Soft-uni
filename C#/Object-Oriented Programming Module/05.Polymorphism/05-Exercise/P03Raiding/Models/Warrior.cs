namespace P03Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;
        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {DefaultPower} damage";
        }
    }
}
