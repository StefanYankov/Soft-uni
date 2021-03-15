using System;
using System.Linq;

using P01Vehicles.Models;
using P01Vehicles.Core.Contracts;
using P01Vehicles.Factories;


namespace P01Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;
        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    ProcessCommands(commandArgs, car, truck);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessCommands(string[] commandArgs, Vehicle car, Vehicle truck)
        {
            string commandType = commandArgs[0];
            string vehicleType = commandArgs[1];
            double argument = double.Parse(commandArgs[2]);

            if (commandType == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(argument));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(argument));
                }
            }
            else if (commandType == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(argument);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(argument);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string type = inputArgs[0];
            double fuelQuantity = double.Parse(inputArgs[1]);
            double fuelConsumption = double.Parse(inputArgs[2]);

            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption);
            return vehicle;
        }
    }


}
