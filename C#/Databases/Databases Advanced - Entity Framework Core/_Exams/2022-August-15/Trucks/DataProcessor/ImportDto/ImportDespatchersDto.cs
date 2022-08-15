using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }
    }
}
