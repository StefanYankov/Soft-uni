using System.Collections.Generic;

namespace _03StudentSystem
{
    public class StudentsDatabase
    {
        private Dictionary<string, Student> collection;

        public StudentsDatabase()
        {
            this.collection = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!this.collection.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                collection[name] = student;
            }
        }

        public Student Find(string name)
        {
            if (this.collection.ContainsKey(name))
            {
                return collection[name];
            }

            return null;
        }
    }
}
