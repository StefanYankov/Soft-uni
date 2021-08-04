namespace P07OrderByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string name = input.Split(" ")[0];
                string id = input.Split(" ")[1];
                byte age = byte.Parse(input.Split(" ")[2]);

                Person person = new Person(name, id, age);
                people.Add(person);
            }

            foreach (var person in people.OrderBy(p => p.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public Person(string name, string id, byte age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public byte Age { get; set; }

    }
}
