using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string root = "Projects";

            var projectsWithTask = context
                .Projects
                .ToArray()
                .Where(x => x.Tasks.Any())
                .Select(x => new ExportProjectsWithTaskDto
                {
                    TasksCount = x.Tasks.Count.ToString(),
                    ProjectName = x.Name,
                    HasEndDate = !string.IsNullOrWhiteSpace(x.DueDate.ToString()) ? "Yes" : "No",
                    Tasks = x.Tasks.Select(t => new ExportTasksDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),
                    })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.ProjectName)
                .ToArray();



            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportProjectsWithTaskDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, projectsWithTask, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .Select( x => new ExportMostBusiestEmployeesDto
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .Select(e => new ExportEmployeeTaskDto
                    {
                        TaskName = e.Task.Name,
                        OpenDate = e.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = e.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = e.Task.LabelType.ToString(),
                        ExecutionType = e.Task.ExecutionType.ToString(),
                    })
                        .OrderByDescending(x => DateTime.Parse(x.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None))
                        .ThenBy(x => x.TaskName)
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;
        }

        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);
            return xmlSerializer;
        }
    }
}