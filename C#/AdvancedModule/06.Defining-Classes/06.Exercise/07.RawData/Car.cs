﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        public string Model { get; set; }

        public Engine engine;

        public Cargo cargo;

        public List<Tire> tires;
    }
}
