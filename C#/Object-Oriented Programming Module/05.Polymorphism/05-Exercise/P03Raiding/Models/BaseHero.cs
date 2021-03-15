using P03Raiding.Models.Contracts;

namespace P03Raiding.Models
{
    public abstract class BaseHero : ICastAbilitable
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }
        public int Power { get; protected set; }
        public virtual string CastAbility()
        {
            return $"{ this.GetType().Name} - {this.Name}";
        }
    }
}
