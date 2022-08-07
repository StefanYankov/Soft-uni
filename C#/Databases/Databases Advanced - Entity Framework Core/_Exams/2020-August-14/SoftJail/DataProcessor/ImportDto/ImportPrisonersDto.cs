using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportPrisonersDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}