namespace Restaurant.Foods.MainDishes
{
    public class Fish : MainDish
    {
        private const double FishGrams = 22;
    public Fish(string name, decimal price, double grams)
        : base(name, price, FishGrams)
    {

    }
}
}
