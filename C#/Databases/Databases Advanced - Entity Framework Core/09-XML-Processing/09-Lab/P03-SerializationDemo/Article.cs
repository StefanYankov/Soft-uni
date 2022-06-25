using System.Xml.Serialization;

namespace P03_SerializationDemo;

[XmlType("Article")]
public class Article
{
    [XmlElement("abstract")]
    public string Abstract { get; set; }

    [XmlElement("title")]
    public string Title { get; set; }

    [XmlElement("url")]
    public string Url { get; set; }

    [XmlIgnore]
    public DateTime CreatedOn { get; set; }

}