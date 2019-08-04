using System;
using System.Collections.Generic;
using System.Text;

namespace _05.SpecialCars
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
