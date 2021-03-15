using System;
using System.Collections.Generic;
using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double DefaultWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => DefaultWeightMultiplier;
        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Vegetable), typeof(Fruit) };
        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
