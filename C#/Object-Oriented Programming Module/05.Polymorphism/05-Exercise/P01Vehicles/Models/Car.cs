namespace P01Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditioner = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditioner;
        }
    }
}
