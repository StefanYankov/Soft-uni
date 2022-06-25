using System;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [Serializable]
    [XmlType("partId")]
    public class PartCarInputModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
