using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class ShoppingSpreeProgram
    {
        static void Main()
        {
            var peoples = new List<Person>();
            var inputPeoples = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var inputPeople in inputPeoples)
            {
                try
                {
                    var currentPerson = inputPeople.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = currentPerson[0];
                    decimal money = decimal.Parse(currentPerson[1]);
                    Person person = new Person(name, money);
                    peoples.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var products = new List<Product>();
            var inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var inputProduct in inputProducts)
            {
                try
                {
                    var currentPerson = inputProduct.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = currentPerson[0];
                    decimal price = decimal.Parse(currentPerson[1]);
                    Product product = new Product(name, price);
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    foreach (var man in peoples)
                    {
                        Console.WriteLine(man);
                    }
                    break;
                }

                var split = command.Split(' ');
                string name = split[0];
                string product = split[1];
                var member = peoples.FirstOrDefault(x => x.Name == name);
                var productToSearchFor = products.FirstOrDefault(x => x.Name == product);
                Console.WriteLine(member.Buy(productToSearchFor));
            }
        }
    }
}