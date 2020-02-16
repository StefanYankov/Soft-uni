using System;
using System.Collections.Generic;
using System.Text;



namespace _05ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person otherPerson)
        {
            // compare their names, after that – their age and finally – their towns
            if (this.Name.CompareTo(otherPerson.Name) != 0)
            {
                return this.Name.CompareTo(otherPerson.Name);
            }

            if (this.Age.CompareTo(otherPerson.Age) != 0)
            {
                return this.Age.CompareTo(otherPerson.Age);
            }

            return this.Town.CompareTo(otherPerson.Town);
        }
    }
}
