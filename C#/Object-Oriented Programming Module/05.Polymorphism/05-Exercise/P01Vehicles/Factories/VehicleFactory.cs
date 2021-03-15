using System;
using P01Vehicles.Models;
using P01Vehicles.Utilities;

namespace P01Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}
