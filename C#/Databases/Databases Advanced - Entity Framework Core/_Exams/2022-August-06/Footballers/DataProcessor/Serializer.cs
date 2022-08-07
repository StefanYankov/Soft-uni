using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Footballers.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            const string root = "Coaches";

            var coachesWithFootballers = context
                .Coaches
                .ToArray()
                .Where(x => x.Footballers.Count > 0)
                .Select(x => new ExportCoachWithTheirFootballersDto
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(f => new ExportCoachFootballersDto
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString(),
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportCoachWithTheirFootballersDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, coachesWithFootballers, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams.Where(x => x.TeamsFootballers.Any(f => f.Footballer.ContractStartDate>= date))
                .ToArray()
                .Select(x => new ExportTeamsWithMostFootballersDto
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers.Where(f => f.Footballer.ContractStartDate > date)
                        .Select(f => new ExportFootballersDto
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType =f.Footballer.PositionType.ToString(),
                        })
                        .OrderByDescending(f => DateTime.Parse(f.ContractEndDate, CultureInfo.InvariantCulture))
                        .ThenBy(f => f.FootballerName)
                        .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Length)
                .ThenBy( x => x.Name)
                .Take(5)
                .ToArray();

            var result = JsonConvert.SerializeObject(teams, Formatting.Indented);
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
