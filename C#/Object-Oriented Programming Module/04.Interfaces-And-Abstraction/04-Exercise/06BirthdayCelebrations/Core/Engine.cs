using System;

using BirthdayCelebrations.Contracts;
using System.Collections.Generic;
using BirthdayCelebrations.Models;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly IList<IBirthdatable> birthdates;

        public Engine()
        {
            this.birthdates = new List<IBirthdatable>();
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputSplit = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputSplit[0] == "Citizen")
                {
                    string name = inputSplit[1];
                    int age = int.Parse(inputSplit[2]);
                    string id = inputSplit[3];
                    string birthdate = inputSplit[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    birthdates.Add(citizen);
                }
                else if (inputSplit[0] == "Pet")
                {
                    string name = inputSplit[1];
                    string birthdate = inputSplit[2];
                    Pet pet = new Pet(name, birthdate);
                    birthdates.Add(pet);
                }
            }
            string year = Console.ReadLine();

            var forPrint = this.birthdates
                .Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)
                .ToList();

            Console.WriteLine(String.Join(Environment.NewLine, forPrint));
        }
    }
}

