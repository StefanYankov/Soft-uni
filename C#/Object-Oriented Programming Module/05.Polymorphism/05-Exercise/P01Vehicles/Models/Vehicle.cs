using System;
using P01Vehicles.Models.Contracts;
using P01Vehicles.Utilities;

namespace P01Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuellable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InsufficientFuel, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";

        }

        public virtual void Refuel(double liters)
        {
            if (liters > 0)
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
