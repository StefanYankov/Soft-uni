namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.Horsepower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public int Horsepower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelNeeded = this.FuelConsumption * kilometers;
            if (this.Fuel >= fuelNeeded)
            {
                this.Fuel -= fuelNeeded;
            }

        }



}
}
