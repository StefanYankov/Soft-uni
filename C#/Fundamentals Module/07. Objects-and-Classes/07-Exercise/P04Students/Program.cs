namespace P04Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> studentList = new List<Student>();
            string studentDetails = string.Empty;
            for (int i = 1; i <= countOfStudents; i++)
            {
                studentDetails = Console.ReadLine();
                string firstName = studentDetails.Split(" ")[0];
                string lastname = studentDetails.Split(" ")[1];
                double grade = double.Parse(studentDetails.Split(" ")[2]);

                Student student = new Student(firstName, lastname, grade);
                studentList.Add(student);
            }

            foreach (var student in studentList.OrderByDescending(g => g.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public Student()
        {

        }
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName:F2} {this.LastName:F2}: {this.Grade:F2}";
        }
    }
}
