using Lab.ModelBuilding;
using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<EmployeeInClub> EmployeesInClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=BG-5CG00410VW;Integrated Security=SSPI;Database=04LabDemoDb;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // call employee configuration
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            // call department configuration
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // call address configuration
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.Entity<EmployeeInClub>().HasKey(x => new {x.EmployeeId, x.ClubId});
        }
    }
}
