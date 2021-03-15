using System;
using System.Collections.Generic;
using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double DefaultWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => DefaultWeightMultiplier;
        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Vegetable), typeof(Meat) };
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
