using CarManager; // to remove when submitting to judge
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        private const string make = "Mercedes";
        private const string model = "CLS";
        private const double fuelConsumption = 7.8;
        private const double fuelAmount = 0;
        private const double fuelCapacity = 80;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void Test_Car_Constructor_Works_Correctly()
        {
            Assert.AreEqual(make, this.car.Make);
            Assert.AreEqual(model, this.car.Model);
            Assert.AreEqual(fuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(fuelAmount, this.car.FuelAmount);
            Assert.AreEqual(fuelCapacity, this.car.FuelCapacity);
        }
        [Test]
        public void Test_If_Car_Make_Is_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Car_Make_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(string.Empty, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Car_Model_Is_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, null, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Car_Model_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, string.Empty, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Fuel_Consumption_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, 0, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Fuel_Consumption_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, -10, fuelCapacity);
            });
        }

        [Test]
        public void Test_If_Fuel_Capacity_Is_Negative()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, -10);
            });
        }

        [Test]
        public void Test_If_Fuel_Capacity_Is_Zero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, 0);
            });
        }

        [Test]
        public void Test_Refueling_With_Zero_Fuel_To_Refuel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }

        [Test]
        public void Test_Refueling_With_Negative_Fuel_To_Refuel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(-10);
            });
        }

        [Test]
        public void Test_If_Refueling_Works_Correctly()
        {
            this.car.Refuel(10);

            int expectedFuelAmount = 10;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void Test_If_FuelAmount_Is_Greater_Than_FuelCapacity_When_Refueling()
        {
            this.car.Refuel(81);

            int expectedFuelAmount = 80;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void Test_If_FuelNeeded_Is_Greater_Than_Fuel_Amount_When_Driving()
        {
            this.car.Refuel(18);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(300);
            });
        }

        [Test]
        public void Test_If_Drive_Works_Correctly()
        {
            this.car.Refuel(80);
            this.car.Drive(1000);
            //             double fuelNeeded = (distance / 100) * this.FuelConsumption;
            double expectedFuelAmount = 2.0;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }
    }
}