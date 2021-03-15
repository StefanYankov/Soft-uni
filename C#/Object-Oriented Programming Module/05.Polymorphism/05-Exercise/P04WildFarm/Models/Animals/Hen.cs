using System;
using System.Collections.Generic;
using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double DefaultWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => DefaultWeightMultiplier;
        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
