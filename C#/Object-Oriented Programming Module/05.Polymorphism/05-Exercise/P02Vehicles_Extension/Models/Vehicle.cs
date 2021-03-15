using System;
using P02Vehicles_Extension.Models.Contracts;
using P02Vehicles_Extension.Utilities;

namespace P02Vehicles_Extension.Models
{
    public abstract class Vehicle : IDrivable, IRefuellable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            CheckIfOverCapacity();
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }


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

        public virtual string DriveEmpty(double distance)
        {
            return Drive(distance);
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }

            if (liters > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.OverfilledTank, liters));
            }

            if (liters > 0)
            {
                this.FuelQuantity += liters;
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        private void CheckIfOverCapacity()
        {
            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }
    }
}
