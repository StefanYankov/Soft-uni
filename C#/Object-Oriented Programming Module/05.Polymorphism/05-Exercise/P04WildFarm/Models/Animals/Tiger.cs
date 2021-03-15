using System;
using System.Collections.Generic;
using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double DefaultWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => DefaultWeightMultiplier;
        public override ICollection<Type> PreferredFoods => new List<Type>() {typeof(Meat)};
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
