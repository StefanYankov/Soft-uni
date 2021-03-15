using System;
using System.Linq;

using P02Vehicles_Extension.Models;
using P02Vehicles_Extension.Core.Contracts;
using P02Vehicles_Extension.Factories;


namespace P02Vehicles_Extension.Core
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
            Vehicle bus = ProduceVehicle();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    ProcessCommands(commandArgs, car, truck, bus);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }

        private static void ProcessCommands(string[] commandArgs, Vehicle car, Vehicle truck, Vehicle bus)
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
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(argument));
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
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(argument);
                }
            }
            else if (commandType == "DriveEmpty")
            {
                Console.WriteLine(bus.Drive(argument));
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
            double tankCapacity = double.Parse(inputArgs[3]);

            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }


}
