using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [Range(0.00,10.00)]
        [XmlElement("Rating")]

        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        // TODO: flag as enum if error
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string ScreenWriter { get; set; }
    }
}
