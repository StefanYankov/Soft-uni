using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab.Models
{
    [Table("People", Schema = "Company")]
    [Index("Egn", IsUnique = true)] // indexes a column. IsUnique makes it unique
    public class Employee
    {
        public Employee()
        {
            // initialize the collection
            this.ClubParticipations = new HashSet<EmployeeInClub>();
        }

        [Key] // primary key with attributes
        public int Id { get; set; }
        public string Egn { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        [Column("StartedOn", TypeName = "date")] // Rename column and change the type of the column to date
        public DateTime? StartWorkDate { get; set; }
        public decimal Salary { get; set; }

        // getting control of the automatically generated DepartmentId by creating it. Optional
        public int? DepartmentId { get; set; }

        // navigational property to create the relation. Required!
        [InverseProperty("Employees")] // optional - not needed
        [ForeignKey("DepartmentId")] // optional - not needed
        public Department Department { get; set; }

        // one to one relationship
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        // many to many relationship

        public ICollection<EmployeeInClub> ClubParticipations { get; set; }
    }
}
