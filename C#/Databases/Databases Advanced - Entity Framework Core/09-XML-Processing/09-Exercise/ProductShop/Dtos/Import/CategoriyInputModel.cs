using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Category")]
    public class CategoriyInputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
