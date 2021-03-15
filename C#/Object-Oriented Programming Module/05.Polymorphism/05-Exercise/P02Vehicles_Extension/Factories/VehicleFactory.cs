using System;
using P02Vehicles_Extension.Models;
using P02Vehicles_Extension.Utilities;

namespace P02Vehicles_Extension.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}
