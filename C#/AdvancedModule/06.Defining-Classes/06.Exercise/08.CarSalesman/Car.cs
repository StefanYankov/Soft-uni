using System;

namespace CarSalesman
{
    public class Car
    {
        public Engine engine;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.engine = engine;
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Model}:" + Environment.NewLine
                + $"  {engine.Model}:" + Environment.NewLine
                + $"    Power: {engine.Power}" + Environment.NewLine
                + $"    Displacement: {engine.Displacement}" + Environment.NewLine
                + $"    Efficiency: {engine.Efficiency}" + Environment.NewLine
                + $"  Weight: {Weight}" + Environment.NewLine
                + $"  Color: {Color}";
        }
    }
}