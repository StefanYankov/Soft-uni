namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car("MK3", "VW", 1992);

            car.Make = "MK3";
            car.Model = "VW";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
