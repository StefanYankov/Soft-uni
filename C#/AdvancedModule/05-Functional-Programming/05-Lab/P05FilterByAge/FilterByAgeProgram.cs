namespace P05FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FilterByAgeProgram
    {
        public static void Main()
        {
           List<Person> people = new List<Person>();
            int countOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfPeople; i++)
            {
                var input = Console.ReadLine().Split(", ");
                var tempPerson = new Person(input[0], int.Parse(input[1]));
                people.Add(tempPerson);
            }

            var condition = Console.ReadLine();
            var ageToCompareWith = int.Parse(Console.ReadLine());
            var printFormat = Console.ReadLine();
            Func<Person, bool> filter = p => true;
            if (condition.Equals("younger"))
            {
                filter = p => p.Age < ageToCompareWith;
            }
            else if (condition.Equals("older"))
            {
                filter = p => p.Age >=  ageToCompareWith;
            }

            var filteredPeople = people.Where(filter);
            Func<Person, string> printFunc = p => p.Name + " " + p.Age; 

            if (printFormat.Equals("name age"))
            {
                printFunc = p => p.Name + " - " + p.Age;
            }
            else if (printFormat.Equals("name"))
            {
                printFunc = p => p.Name;
            }
            else if (printFormat.Equals("age"))
            {
                printFunc = p => p.Age.ToString();
            }

            var personAsString = filteredPeople.Select(printFunc);

            foreach (var person in personAsString)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
