using System;
using System.Collections.Generic;
using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double DefaultWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => DefaultWeightMultiplier;
        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat) };
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
