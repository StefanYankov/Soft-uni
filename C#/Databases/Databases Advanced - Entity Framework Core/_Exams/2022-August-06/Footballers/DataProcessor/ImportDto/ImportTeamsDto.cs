using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsDto
    {
        [RegularExpression(@"^[A-Za-z\d\.\-\s]+$")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        public string Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
