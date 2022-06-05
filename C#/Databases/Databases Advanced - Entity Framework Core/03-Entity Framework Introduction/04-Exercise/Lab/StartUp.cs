using System;
using Lab.Data;
using Lab.Models;

namespace Lab
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // ALTER AUTHORIZATION ON DATABASE::[04LabDemoDb] TO sa
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = AddDepartment(db);
            AddEmployees(db, department);

            db.SaveChanges();
        }

        private static Department AddDepartment(ApplicationDbContext db)
        {
            return new Department() {Name = "Applications"};
        }


        private static void AddEmployees(ApplicationDbContext db, Department department)
        {
            Random rand = new Random();



            db.Employees.Add(new Employee()
            {
                Egn = rand.Next(1000, 9999).ToString() + rand.Next(1000,9999),
                FirstName = "Serafim",
                LastName = "Gerasimoff",
                StartWorkDate = RandomDay(),
                Salary = rand.Next(90000, 120000),
                Department = department,
            });

            db.Employees.Add(new Employee()
            {
                Egn = rand.Next(1000, 9999).ToString() + rand.Next(1000, 9999),
                FirstName = "Dala",
                LastName = "Vera",
                StartWorkDate = RandomDay(),
                Salary = rand.Next(90000, 120000),
                Department = department,
            });

            db.Employees.Add(new Employee()
            {
                Egn = rand.Next(1000, 9999).ToString() + rand.Next(1000, 9999),
                FirstName = "Kaka",
                LastName = "Penka",
                StartWorkDate = RandomDay(),
                Salary = rand.Next(90000, 120000),
                Department = department,
            });
        }

        static DateTime RandomDay()
        {
            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}
