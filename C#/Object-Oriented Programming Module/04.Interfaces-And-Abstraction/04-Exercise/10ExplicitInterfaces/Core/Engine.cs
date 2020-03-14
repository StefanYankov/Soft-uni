using System;
using System.Collections.Generic;

using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Exceptions;
using ExplicitInterfaces.Models;


namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        private readonly List<Citizen> citizens;


        public Engine()
        {
            this.citizens = new List<Citizen>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInformation = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string citizenName = citizenInformation[0];
                string citizenCountry = citizenInformation[1];
                int citizenAge = int.Parse(citizenInformation[2]);

                Citizen citizen = new Citizen(citizenName, citizenCountry, citizenAge);

                this.citizens.Add(citizen);
            }

            try
            {
                PrintPeople();
            }
            catch (InvalidPersonTypeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintPeople()
        {
            foreach (var person in this.citizens)
            {
                if (person is IPerson castedPerson)
                {
                    Console.WriteLine(castedPerson.GetName());
                }
                else
                {
                    throw new InvalidPersonTypeException();
                }

                if (person is IResident castedResident)
                {
                    Console.WriteLine(castedResident.GetName());
                }
                else
                {
                    throw new InvalidPersonTypeException();
                }
            }
        }
    }
}