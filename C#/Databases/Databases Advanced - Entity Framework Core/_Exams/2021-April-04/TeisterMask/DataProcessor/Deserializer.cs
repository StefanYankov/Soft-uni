using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string root = "Projects";
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ImportProjectsDto[]));

            using var stringReader = new StringReader(xmlString);

            var projectsDto = (ImportProjectsDto[])xmlSerializer.Deserialize(stringReader);

            List<Project> projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;


                var isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime dueDateNotNull;
                    var isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dueDateNotNull);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateNotNull;
                }

                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                };

                List<Task> tasksToAdd = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    DateTime taskDueDate;

                    var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskOpenDate);
                    var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if ((taskOpenDate < openDate) || (dueDate != null && taskDueDate > dueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType) taskDto.ExecutionType,
                        LabelType = (LabelType) taskDto.LabelType,
                    };

                    tasksToAdd.Add(task);
                }

                project.Tasks = tasksToAdd;

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));

            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var employeesDto = JsonConvert.DeserializeObject<List<ImportEmployeesDto>>(jsonString);

            List<Employee> employeesToAdd = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                List<EmployeeTask> employeeTasks = new List<EmployeeTask>();

                foreach (var taskDto in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.Find(taskDto);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTaskToAdd = new EmployeeTask
                    {
                        Employee = employee,
                        Task = task,
                    };

                    if (employeeTasks.Contains(employeeTaskToAdd))
                    {
                        continue;
                    }
                    employeeTasks.Add(employeeTaskToAdd);
                }
                employee.EmployeesTasks = employeeTasks;

                employeesToAdd.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, $"{employee.Username}", employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employeesToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);
            return xmlSerializer;
        }
    }
}