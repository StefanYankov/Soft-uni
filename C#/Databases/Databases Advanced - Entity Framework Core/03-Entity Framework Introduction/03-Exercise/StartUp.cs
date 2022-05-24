using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            // string connectionString = @"Server=BG-5CG00410VW;Integrated Security=SSPI;Database=SoftUni;TrustServerCertificate=True;";
            // dotnet ef dbcontext scaffold "Server=BG-5CG00410VW;Integrated Security=SSPI;Database=SoftUni;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

            // Problem #02
            // Scaffold-DbContext -Connection "Server=.;Integrated Security=True;Database=SoftUni;TrustServerCertificate=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models

            var db = new SoftUniContext();

            // Problem #03
            // Console.WriteLine(GetEmployeesFullInformation(db));
            // Problem #04
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            // Problem #05
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            // Problem #06
            // Console.WriteLine(AddNewAddressToEmployee(db));
            // Problem #07
            // Console.WriteLine(GetEmployeesInPeriod(db));
            // Problem #08
            // Console.WriteLine(GetAddressesByTown(db));
            // Problem #09
            // Console.WriteLine(GetEmployee147(db));
            // Problem #10
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));
            // Problem #11
            // Console.WriteLine(GetLatestProjects(db));
            // Problem #12
            // Console.WriteLine(IncreaseSalaries(db));
            // Problem #13
            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
            // Problem #14
            // Console.WriteLine(DeleteProjectById(db));
            // Problem #15
            Console.WriteLine(RemoveTown(db));
        }

        // Problem #03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDetails = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = string.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    Salary = $"{e.Salary:F2}"
                })
                .ToList();

            foreach (var employee in employeesDetails)
            {
                sb.AppendLine(string.Join(" ", employee.Name, employee.JobTitle, employee.Salary));
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDetails = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    Salary = $"{e.Salary:F2}"
                }
                )
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var employee in employeesDetails)
            {
                sb.AppendLine(string.Join(" - ", employee.FirstName, employee.Salary));
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDetails = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employeesDetails)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            var topTenEmployeesAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, topTenEmployeesAddresses);
        }

        // Problem #07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDetails = context.Employees
                .Include(ep => ep.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Where(ep => ep.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        Name = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })

                }
                    )
                .Take(10)
                .ToArray();

            foreach (var employee in employeesDetails)
            {
                sb.AppendLine(
                    $"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {
                    sb.Append($"--{project.Name} - {project.StartDate:M/d/yyyy h:mm:ss tt} - ");
                    sb.Append(project.EndDate == null
                        ? "not finished"
                        : $"{project.EndDate.Value:M/d/yyyy h:mm:ss tt}");

                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Include(e => e.Employees)
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    Text = a.AddressText,
                    Town = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToArray();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Text}, {address.Town} - {string.Join("@", address.EmployeesCount)} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #09
        public static string GetEmployee147(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();
            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    ProjectNames = e.EmployeesProjects.OrderBy(p => p.Project.Name).Select(p => new
                    {
                        p.Project.Name
                    })
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.ProjectNames)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmployeesList = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.EmployeesList)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                ;

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}")
                    .AppendLine($"{project.Description}")
                    .AppendLine($"{project.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            const decimal salaryModifier = 0.12m;
            var departmentsInScope = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            List<Employee> employees = context.Employees
                .Where(e => departmentsInScope.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary = employee.Salary + employee.Salary * salaryModifier;
            }

            context.SaveChanges();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        // Problem #13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            const int projectId = 2;

            var projectToRemove = context.Projects.Find(projectId);

            context.EmployeesProjects.ToList().ForEach(ep => context.EmployeesProjects.Remove(ep));

            context.Projects.Remove(projectToRemove);
            
            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select( p => new
                {
                    p.Name
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem #15
        public static string RemoveTown(SoftUniContext context)
        {

            const string toRemove = "Seattle";

            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name == toRemove)
                .ToArray();

            var employeesInTownToRemove = context.Employees
                .ToArray()
                .Where(e => addressesToRemove.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (var employee in employeesInTownToRemove)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToRemove);

            Town townToRemove = context.Towns
                .First(t => t.Name == toRemove);
            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addressesToRemove.Length} addresses in {toRemove} were deleted";
        }
    }
}