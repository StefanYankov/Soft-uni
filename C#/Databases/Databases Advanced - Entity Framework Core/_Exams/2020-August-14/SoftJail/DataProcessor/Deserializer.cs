using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedDepartmentAndCells = "Imported {0} with {1} cells";
        public const string SuccessfullyImportedPrisonersMails = "Imported {0} {1} years old";
        public const string SuccessfullyImportOfficersPrisoners = "Imported {0} ({1} prisoners)";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentCells = JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentsCellsDto>>(jsonString);

            List<Department> departmentsToImport = new List<Department>();

            foreach (var departmentCell in departmentCells)
            {
                if (!IsValid(departmentCell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!departmentCell.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (departmentCell.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department
                {
                    Name = departmentCell.Name,
                    Cells = departmentCell.Cells.Select( x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow,
                    })
                        .ToArray()
                };



                departmentsToImport.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartmentAndCells, department.Name,
                    department.Cells.Count));
            }

            context.Departments.AddRange(departmentsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonerMails = JsonConvert.DeserializeObject<IEnumerable<ImportPrisonerMailDto>>(jsonString);

            List<Prisoner> prisonersToImport = new List<Prisoner>();

            foreach (var prisonerMail in prisonerMails)
            {

                if (!IsValid(prisonerMail))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!prisonerMail.Mails.Any(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;

                var isDateValid = DateTime.TryParseExact(prisonerMail.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                DateTime? releaseDate = null;

                if (prisonerMail.ReleaseDate != null)
                {
                    releaseDate = DateTime.ParseExact(prisonerMail.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }


                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerMail.FullName,
                    Nickname = prisonerMail.Nickname,
                    Age = prisonerMail.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerMail.Bail,
                    CellId = prisonerMail.CellId,
                    Mails = prisonerMail.Mails.Select(x => new Mail
                        {
                            Description = x.Description,
                            Sender = x.Sender,
                            Address = x.Address,
                        })
                        .ToArray()
                };

                prisonersToImport.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisonersMails, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisonersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Officers");
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var officersDto = (ImportOfficersPrisonersDto[])xmlSerializer.Deserialize(stringReader);

            List<Officer> officersToImport = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Position position;
                Weapon weapon;

                if (!Enum.TryParse(officerDto.Position, out position) || !Enum.TryParse(officerDto.Weapon, out weapon))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                };

                List<OfficerPrisoner> officerPrisonersToAdd = new List<OfficerPrisoner>();

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var prisoner = context.Prisoners.Find(int.Parse(prisonerDto.Id));

                    //if (prisoner == null)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    OfficerPrisoner officerPrisonerToAdd = new OfficerPrisoner
                    {
                        Prisoner = prisoner,
                        Officer = officer,
                    };

                    if (officerPrisonersToAdd.Contains(officerPrisonerToAdd))
                    {
                        continue;
                    }

                    officerPrisonersToAdd.Add(officerPrisonerToAdd);
                }

                officer.OfficerPrisoners = officerPrisonersToAdd;


                officersToImport.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportOfficersPrisoners, $"{officer.FullName}", $"{officer.OfficerPrisoners.Count}"));
            }
            context.Officers.AddRange(officersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}