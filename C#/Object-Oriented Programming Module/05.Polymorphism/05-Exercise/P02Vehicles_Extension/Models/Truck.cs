namespace P02Vehicles_Extension.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditioner = 1.6;
        private const double TankCapacityModifier = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditioner;
        }

        public override void Refuel(double liters)
        {
            if (liters > this.TankCapacity)
            {
                base.Refuel(liters);
            }
            base.Refuel(liters * TankCapacityModifier);
        }
    }
}
