using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                // {model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                double firstTirePressure = double.Parse(input[5]);
                int firstTireAge = int.Parse(input[6]);
                double secondTirePressure = double.Parse(input[7]);
                int secondTireAge = int.Parse(input[8]);
                double thirdTirePressure = double.Parse(input[9]);
                int thirdTireAge = int.Parse(input[10]);
                double fourthTirePressure = double.Parse(input[11]);
                int fourthTireAge = int.Parse(input[12]);

                Tire firstTire = new Tire(firstTirePressure, firstTireAge);
                Tire secondTire = new Tire(secondTirePressure, secondTireAge);
                Tire thirdTire = new Tire(thirdTirePressure, thirdTireAge);
                Tire fourthTire = new Tire(fourthTirePressure, fourthTireAge);

                List<Tire> tires = new List<Tire>(4)
                {
                    firstTire,
                    secondTire,
                    thirdTire,
                    fourthTire
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars
                    .Where(c => c.cargo.cargoType == "fragile")
                    .Where(c => c.tires.Any(t => t.tirePressure < 1))
                    .Select(m => m.Model)
                    .ToList()
                    .ForEach(m => Console.WriteLine(m));
            }
            else if (command == "flamable")
            {
                cars
                    .Where(c => c.cargo.cargoType == "flamable")
                    .Where(e => e.engine.enginePower > 250)
                    .Select(m => m.Model)
                    .ToList()
                    .ForEach(m => Console.WriteLine(m));
            }
        }
    }
}
