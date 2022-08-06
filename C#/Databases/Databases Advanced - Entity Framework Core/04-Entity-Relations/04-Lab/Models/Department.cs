using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key] // primary key with attributes
        public int Id { get; set; }
        public string Name { get; set; }

        // Inverse property - optional
        public ICollection<Employee> Employees { get; set; }
    }
}
