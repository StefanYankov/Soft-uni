using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+[ ]{1}[A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress] // TODO: check if validation is needed
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
