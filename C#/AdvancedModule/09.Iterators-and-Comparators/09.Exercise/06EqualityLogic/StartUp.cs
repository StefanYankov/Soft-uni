using System;
using System.Collections.Generic;

namespace _06EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> sortedPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
