namespace P03Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;
        public Rogue(string name) 
            : base(name, DefaultPower)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {DefaultPower} damage";
        }
    }
}
