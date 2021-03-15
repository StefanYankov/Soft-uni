namespace P01Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditioner = 1.6;
        private const double TankCapacityModifier = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditioner;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TankCapacityModifier);
        }
    }
}
