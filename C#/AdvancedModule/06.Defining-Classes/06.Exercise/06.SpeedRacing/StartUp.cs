using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    using System;
    class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carsData[0];
                double fuelAmount = double.Parse(carsData[1]);
                double fuelConsumptionPerKilometer = double.Parse(carsData[2]);

                Car car = new Car(carModel, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] data = inputLine.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string carModel = data[1];
                double distance = double.Parse(data[2]);

                Car car = cars.FirstOrDefault(c => c.Model == carModel);
                car.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
