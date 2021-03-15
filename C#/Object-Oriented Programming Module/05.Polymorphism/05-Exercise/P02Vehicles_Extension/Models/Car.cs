namespace P02Vehicles_Extension.Models
{
    public class Car : Vehicle
    {
        private const double AirConditioner = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditioner;
        }
    }
}
