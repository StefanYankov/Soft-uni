using MiniORM.MiniORM.App.Data.Models;

namespace MiniORM.MiniORM.App
{
    using System.Linq;
    using Data;

    public class StartUp
    {
        private static string connectionString = @"Server=.;Database=MiniORM;Integrated Security=True";

        public static void Main()
        {
            var context = new SoftUniDbContext(connectionString);

            context.EmployeesProjects.Add(new EmployeeProject { ProjectId = 2, EmployeeId = 2 });

            context.SaveChanges();

            var employeesProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            var project = context.Projects
                .FirstOrDefault(p => p.Id == 2);

            context.EmployeesProjects.RemoveRange(employeesProjects);

            context.SaveChanges();

            context.Projects.Remove(project);

            context.SaveChanges();
        }
    }
}