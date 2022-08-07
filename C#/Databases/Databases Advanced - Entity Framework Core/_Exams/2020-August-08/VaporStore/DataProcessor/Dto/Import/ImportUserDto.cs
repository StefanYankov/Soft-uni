using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+[ ]{1}[A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress] // TODO: check if validation is needed
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public virtual ICollection<ImportUserCardDto> Cards { get; set; }
    }
}


/*
 *
 * {
		"FullName": "",
		"Username": "invalid",
		"Email": "invalid@invalid.com",
		"Age": 20,
		"Cards": [
			{
				"Number": "1111 1111 1111 1111",
				"CVC": "111",
				"Type": "Debit"
			}
		]
	
 */