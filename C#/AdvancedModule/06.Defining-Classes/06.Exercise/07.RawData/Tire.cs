using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tire
    {
        public double tirePressure;
        public int tireAge;

        public Tire(double tirePressure, int tireAge)
        {
            this.tirePressure = tirePressure;
            this.tireAge = tireAge;
        }
    }
}
