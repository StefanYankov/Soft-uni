using P04WildFarm.Models.Foods.Contracts;

namespace P04WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }

        public string ProduceSound();

        void Feed(IFood food);
    }
}
