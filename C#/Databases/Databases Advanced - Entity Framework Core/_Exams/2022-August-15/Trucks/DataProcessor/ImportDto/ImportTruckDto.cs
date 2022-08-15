using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression("^[A-Z]{2}\\d{4}[A-Z]{2}$")]
        // TODO: Min length and regex text with length 8.
        // First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again
        public string RegistrationNumber { get; set; }


        [XmlElement("VinNumber")]
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VinNumber { get; set; }


        [XmlElement("TankCapacity")]
        //TODO: check not required
        [Range(950, 1420)]
        public int TankCapacity { get; set; }


        [XmlElement("CargoCapacity")]
        //TODO: check not required
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }


        [XmlElement("CategoryType")]
        [Required]
        [Range(0,3)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required]
        [Range(0, 4)]
        public int MakeType { get; set; }

    }
}