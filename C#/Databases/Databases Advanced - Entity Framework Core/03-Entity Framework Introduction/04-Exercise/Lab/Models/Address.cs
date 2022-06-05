using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
