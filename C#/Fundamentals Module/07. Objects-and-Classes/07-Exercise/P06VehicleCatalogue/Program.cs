namespace P06VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");
                string vehicleType = tokens[0];
                string vehicleModel = tokens[1];
                string vehicleColor = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                Vehicle currentVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, horsePower);
                catalogue.Add(currentVehicle);
            }

            string model = string.Empty;
            while ((model = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(catalogue.Find(x => x.Model == model));
            }

            var cars = catalogue.Where(x => x.Type == "car").ToList(); 
            var trucks = catalogue.Where(x => x.Type == "truck").ToList(); 

            double totalCarsHorsePower = default(double);
            double totalTrucksHorsePower = default(double);

            cars.ForEach(c => totalCarsHorsePower += c.HorsePower);
            trucks.ForEach(t => totalTrucksHorsePower += t.HorsePower);

            double averageCarsHorsePower = totalCarsHorsePower / cars.Count;
            double averageTrucksHorsePower = totalTrucksHorsePower / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: {(Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {Model}{Environment.NewLine}" +
                                $"Color: {Color}{Environment.NewLine}" +
                                $"Horsepower: {HorsePower}";
        }
    }
}