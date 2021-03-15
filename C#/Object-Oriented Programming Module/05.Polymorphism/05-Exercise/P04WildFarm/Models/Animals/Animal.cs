using P04WildFarm.Models.Animals.Contracts;
using P04WildFarm.Models.Foods.Contracts;
using P04WildFarm.Utility.Exceptions;
using System;
using System.Collections.Generic;

namespace P04WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string DoesNotEatFoodException = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> PreferredFoods { get; }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract string ProduceSound();
        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType())) // to doyble check
            {
                throw new DoesNotEatFoodException(String.Format(DoesNotEatFoodException, this.GetType().Name,
                    food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
