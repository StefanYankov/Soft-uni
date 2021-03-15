using P04WildFarm.Core.Contracts;
using P04WildFarm.Factory;
using P04WildFarm.Models.Animals;
using P04WildFarm.Models.Animals.Contracts;
using P04WildFarm.Models.Foods.Contracts;
using P04WildFarm.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArguments = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string[] foodArguments = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IAnimal animal = ProduceAnimal(animalArguments);
                IFood food = this.foodFactory.ProduceFood(foodArguments[0], int.Parse(foodArguments[1]));

                Console.WriteLine(animal.ProduceSound());

                this.animals.Add(animal);
                try
                {
                    animal.Feed(food);
                }
                catch (DoesNotEatFoodException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IAnimal ProduceAnimal(string[] animalArguments)
        {
            IAnimal animal = null;

            string animalType = animalArguments[0];
            string name = animalArguments[1];
            double weight = double.Parse(animalArguments[2]);

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalArguments[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArguments[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArguments[3];
                if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArguments[4];
                    if (animalType == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (animalType == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }
            }

            return animal;
        }
    }
}
