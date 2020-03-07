using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods.Desserts
{
    public class Cake : Dessert
    {

        private const decimal CakePrice = 5m;

        private const double Grams = 250;

        private const double CakeCalories = 1000;
        public Cake(string name, decimal price)
            : base(name, CakePrice, Grams, CakeCalories)
        {

        }
    }
}
