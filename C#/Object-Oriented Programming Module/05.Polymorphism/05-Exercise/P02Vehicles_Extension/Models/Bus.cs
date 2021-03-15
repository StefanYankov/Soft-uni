namespace P02Vehicles_Extension.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditioner = 1.40;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditioner;
        }

        public override string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AirConditioner;
            return base.Drive(distance);
        }
    }
}
