using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public abstract class Human : IHuman
    {
        private const int FOOD = 0;

        private int food;


        protected Human(string name, int age)
        {
           this.Name = name;
           this.Age = age;
           this.food = FOOD;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.Name} {this.Age}";
        }
    }
}
