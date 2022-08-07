using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserCardDto
    {
        [Required]
        [RegularExpression(@"^\d{4}[ ]{1}\d{4}[ ]{1}\d{4}[ ]{1}\d{4}$")]
        public string Number { get; set; }

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }

    }
}
