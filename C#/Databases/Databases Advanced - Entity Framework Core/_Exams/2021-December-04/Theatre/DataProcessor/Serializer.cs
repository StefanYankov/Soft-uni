using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {

            var theatres = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new ExportTheatersDto
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Select(t => new ExportTicketsDto
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                        .OrderByDescending(t => t.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);
            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            const string root = "Plays";
            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlaysDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(a => a.IsMainCharacter).Select(a => new ExportActorsDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in \'{x.Title}\'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()

                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();



            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportPlaysDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, plays, namespaces);
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
