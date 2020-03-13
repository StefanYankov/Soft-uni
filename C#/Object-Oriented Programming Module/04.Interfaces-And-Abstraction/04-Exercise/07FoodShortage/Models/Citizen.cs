using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Citizen : Human, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }
        public void BuyFood()
        {
            Food += 10;
        }

        public override string ToString()
        {
            return nameof(Rebel) + @"/" + base.ToString() + $" food: {this.Food} ";
        }
    }
}
