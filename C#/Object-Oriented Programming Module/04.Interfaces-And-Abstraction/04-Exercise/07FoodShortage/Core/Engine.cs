using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Contracts;
using FoodShortage.Models;

namespace FoodShortage.Core
{
    public class Engine
    {
        private readonly List<IBuyer> people;

        public Engine()
        {
            this.people = new List<IBuyer>();
        }

        public IReadOnlyCollection<IBuyer> People
        {
            get
            {
                return this.people;
            }
        }

        public void Run()
        {
            int countOfPeople = int.Parse(Console.ReadLine());


            //citz "<name> <age> <id> <birthdate>" 
            //rebel "<name> <age> <group>" 
            for (int i = 0; i < countOfPeople; i++)
            {
                string input = Console.ReadLine();
                string[] splitInput = input.Split(" ").ToArray();
                string name = splitInput[0];
                int age = int.Parse(splitInput[1]);

                if (splitInput.Length == 3)
                {
                    string group = splitInput[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
                else
                {
                    string id = splitInput[2];
                    string birthDate = splitInput[3];
                    IBuyer citizen = new Citizen(name, age, id, birthDate);
                    people.Add(citizen);
                }
            }

            string nameOfBuyer = string.Empty;
            while ((nameOfBuyer = Console.ReadLine()) != "End")
            {
                IBuyer buyer = this.People
                    .FirstOrDefault(p => p.Name == nameOfBuyer);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            int totalAmountOfFood = this.People.Sum(p => p.Food);

            Console.WriteLine(totalAmountOfFood);

        }


    }
}
