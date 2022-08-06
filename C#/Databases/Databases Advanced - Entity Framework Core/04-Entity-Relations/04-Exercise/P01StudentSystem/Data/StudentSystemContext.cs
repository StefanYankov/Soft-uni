using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=BG-5CG00410VW;Integrated Security=SSPI;Database=StudentSystem;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // student
            // modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.Entity<Student>().Property(s => s.Name).IsUnicode(true);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).IsRequired(false).IsUnicode(false);
            // course
            // modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.Entity<Course>().Property(c => c.Name).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsUnicode(true).IsRequired(false);
            // resource
            // modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.Entity<Resource>().Property(r => r.Name).IsUnicode(true);
            modelBuilder.Entity<Resource>().Property(r => r.Url).IsUnicode(false);
            modelBuilder.Entity<Resource>().Property(r => r.ResourceType).HasConversion(et => et.ToString(), et => (ResourceType)Enum.Parse(typeof(ResourceType), et));

            // StudentCourse
            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CourseId });

            // Homework
            // modelBuilder.ApplyConfiguration(new HomeworkConfiguration());

            modelBuilder.Entity<Homework>().Property(h => h.Content).IsUnicode(false);
        }
    }
}
