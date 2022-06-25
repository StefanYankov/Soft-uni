using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class BmwCarOutputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TraveledDistance { get; set; }
    }
}
