﻿using System.Text;

namespace _02Cars.Cars
{
    class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine($"{this.Start()}");
            sb.AppendLine($"{this.Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}