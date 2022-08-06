using System;
using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    // many to many class
    public class EmployeeInClub
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
