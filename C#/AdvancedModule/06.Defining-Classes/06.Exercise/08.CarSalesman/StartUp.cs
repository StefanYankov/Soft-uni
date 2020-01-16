using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>(0);
            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);

                if (engineInput.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (engineInput.Length == 3)
                {
                    int displacement = 0;
                    bool isDisplacement = int.TryParse(engineInput[2], out displacement);

                    if (isDisplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = engineInput[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (engineInput.Length == 4)
                {
                    int displacement = int.Parse(engineInput[2]);
                    string efficiency = engineInput[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                string[] carInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInput[0];
                string engineModel = carInput[1];
                Engine engine = new Engine(null, 0);

                foreach (Engine eng in engines)
                {
                    if (eng.Model == engineModel)
                    {
                        engine = eng;
                    }
                }

                if (carInput.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (carInput.Length == 3)
                {
                    int weight = 0;
                    bool isWeight = int.TryParse(carInput[2], out weight);

                    if (isWeight)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = carInput[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (carInput.Length == 4)
                {
                    int weight = int.Parse(carInput[2]);
                    string color = carInput[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine("{0}:", car.Model);
                Console.WriteLine("  {0}:", car.engine.Model);
                Console.WriteLine("    Power: {0}", car.engine.Power);
                Console.WriteLine("    Displacement: {0}", car.engine.Displacement == 0 ? "n/a" : car.engine.Displacement.ToString());
                Console.WriteLine("    Efficiency: {0}", car.engine.Efficiency);
                Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
                Console.WriteLine("  Color: {0}", car.Color);
            }
        }
    }
}