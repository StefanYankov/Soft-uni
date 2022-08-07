using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellsDto
    {
        [XmlElement("ShellWeight")]
        [Required]
        [Range(2.0, 1_680.0)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Caliber { get; set; }
    }
}
