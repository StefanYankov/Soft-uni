using System;
using System.Linq;

namespace _04PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
                string pizzaName = Console.ReadLine()
               .Split()[1]; // splitting and getting the first element;

                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string flourType = input[1];
                string backingType = input[2];
                double weigth = double.Parse(input[3]);

                Dough dough = new Dough(flourType, backingType, weigth);
                Pizza pizza = new Pizza(pizzaName, dough);


                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingInput = command
                        .Split()
                        .ToArray();

                    string toppingType = toppingInput[1];
                    double toppingWeigth = double.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeigth);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
			catch (Exception ex)
			{

                Console.WriteLine(ex.Message);
			}
        }
    }

}
