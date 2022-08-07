
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using System;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var gunTypeEnum = Enum.Parse<GunType>("AntiAircraftGun");
            var shells = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x =>  new ExportShellDto
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns.Where(g => g.GunType == GunType.AntiAircraftGun).Select(g => new ExportGunDto
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range",

                    })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();
            var result = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            const string root = "Guns";
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new ExportGunsDto
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns.Where(c => c.Country.ArmySize > 4500000).Select(c => new CountryDto
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize,
                    }).OrderBy(x => x.ArmySize)
                        .ToArray(),
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(ExportGunsDto[]));
            using StringWriter sw = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(sw, guns, namespaces);
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
