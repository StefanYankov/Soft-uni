namespace P03NeedForSpeedIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string,Car> cars = new Dictionary<string, Car>();
            for (int i = 1; i <= numberOfCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                var name = carDetails[0];
                var mileage = int.Parse(carDetails[1]);
                var fuel = int.Parse(carDetails[2]);
                Car car = new Car(name, mileage, fuel);
                cars[name] = car;
            }

            string commands = string.Empty;
            while (!(commands=Console.ReadLine()).Equals("Stop"))
            {
                var commandsArr = commands.Split(":", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToArray();
                var command = commandsArr[0];
                var carName = commandsArr[1];
                int distance = 0;
                int fuel = 0;
                switch (command)
                {
                    case "Drive":
                        distance = int.Parse(commandsArr[2]);
                        fuel = int.Parse(commandsArr[3]);
                        cars[carName].Drive(distance, fuel);
                        if (cars[carName].Mileage >= 100_000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }

                        break;
                    case "Refuel":
                        fuel = int.Parse(commandsArr[2]);
                        cars[carName].Refuel(fuel);
                        break;
                    case "Revert":
                        int kilometers = int.Parse(commandsArr[2]);
                        cars[carName].Revert(kilometers);
                        break;
                }
            }

            foreach (var car in cars.OrderByDescending(c => c.Value.Mileage).ThenBy(c => c.Value.Name))
            {
                Console.WriteLine($"{car.Value.Name} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    public class Car
    {
        private int _fuel;
        private const int TankMaxCapacity = 75;
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel
        {
            get => _fuel;
            set
            {
                if (value > TankMaxCapacity)
                {
                    _fuel = TankMaxCapacity;
                }
                else
                {
                    _fuel = value;
                }
            }
        }

        public void Drive(int distance, int fuel)
        {
            if (this.Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            this.Mileage += distance;
            this.Fuel -= fuel;
            Console.WriteLine($"{this.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
        }

        public void Refuel(int fuel)
        {
            int refuledLiters = 0;
            if ((this.Fuel + fuel) > TankMaxCapacity)
            {
                refuledLiters = TankMaxCapacity - this.Fuel;

                this.Fuel = TankMaxCapacity;
            }
            else
            {
                this.Fuel += fuel;
                refuledLiters = fuel;
            }

            Console.WriteLine($"{this.Name} refueled with {refuledLiters} liters");
        }

        public void Revert(int kilometers)
        {
            this.Mileage -= kilometers;
            if (this.Mileage < 10000)
            {
                this.Mileage = 10000;
                return;
            }

            Console.WriteLine($"{this.Name} mileage decreased by {kilometers} kilometers");
        }
    }
}
