﻿namespace NeedForSpeed.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FUEL_CONSUMPTIOPN = 8;
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTIOPN;
    }
}
