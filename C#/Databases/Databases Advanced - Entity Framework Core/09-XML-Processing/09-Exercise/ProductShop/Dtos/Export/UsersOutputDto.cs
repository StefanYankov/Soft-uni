using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class UsersOutputDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserInfoDto[] Users { get; set; }
    }
}