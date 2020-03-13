using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Rebel : Human, IBuyer
    {
        private string group;
        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group {get; private set;}
        public int Food { get; private set; }
        public void BuyFood()
        {
            Food += 5;
        }

        public override string ToString()
        {
            return nameof(Rebel) + @"/" + base.ToString() + $" food: {this.Food}" + $"from group {this.Group}.";
        }
    }
}
