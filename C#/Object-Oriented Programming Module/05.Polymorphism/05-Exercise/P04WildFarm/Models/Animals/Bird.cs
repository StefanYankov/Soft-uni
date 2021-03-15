using System.Text;

namespace P04WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append($" {this.WingSize}, {this.Weight}, {this.FoodEaten}]");

            return sb.ToString();
        }
    }
}
