using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lab.Models
{
    public class Club
    {

        public Club()
        {
            this.Employees = new HashSet<EmployeeInClub>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeInClub> Employees { get; set; }
    }
}
