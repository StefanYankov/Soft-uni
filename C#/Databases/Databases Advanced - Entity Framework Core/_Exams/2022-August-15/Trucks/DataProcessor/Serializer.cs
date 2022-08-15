using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using System;
    using Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            const string root = "Despatchers";

            var despatchersWithTrucks = context
                .Despatchers
                .ToArray()
                .Where(x => x.Trucks.Count > 0)
                .Select(x => new ExportDespatchersWithTheirTrucksDto
                {
                    TrucksCount = x.Trucks.Count,
                    DespatcherName = x.Name,
                    Trucks = x.Trucks.Select(t => new ExportDespatcherTruckDto
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString(),
                    })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(x => x.TrucksCount)
                .ThenBy(x => x.DespatcherName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportDespatchersWithTheirTrucksDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, despatchersWithTrucks, namespaces);
            return sb.ToString().TrimEnd();

        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithMostTrucks = context
                .Clients
                .Where(x => x.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(x => new ExportClientsWithMostTrucksDto
                {
                    Name = x.Name,
                    Trucks = x.ClientsTrucks.Where(t => t.Truck.TankCapacity >= capacity)
                        .Select(t => new ExportTruckDto
                    {
                        TruckRegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber = t.Truck.VinNumber,
                        TankCapacity = t.Truck.TankCapacity,
                        CargoCapacity = t.Truck.CargoCapacity,
                        CategoryType = t.Truck.CategoryType.ToString(),
                        MakeType = t.Truck.MakeType.ToString(),

                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(x => x.Trucks.Length)
                .ThenBy(x => x.Name)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(clientsWithMostTrucks, Formatting.Indented);
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
