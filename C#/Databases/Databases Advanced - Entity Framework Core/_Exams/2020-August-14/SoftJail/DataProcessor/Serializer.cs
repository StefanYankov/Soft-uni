using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new ExportPrisonersByCellsDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(po => new ExportOfficersDto
                        {
                                OfficerName = po.Officer.FullName,
                                Department = po.Officer.Department.Name,
                        })
                        .OrderBy(x => x.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum( o => o.Officer.Salary).ToString("F2")),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();


            var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            const string root = "Prisoners";

            var prisonersArray = prisonersNames.Split(",").ToArray();

            var prisoners = context
                .Prisoners
                .Where(x => prisonersArray.Contains(x.FullName))
                .Select(x => new ExportPrisonersInboxDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails
                        .Select(m => new ExportPrisonerMailDto()
                        {
                            Description = string.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportPrisonersInboxDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, prisoners, namespaces);
            return sb.ToString().TrimEnd();
        }

        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);
            return xmlSerializer;
        }
    }
}