using Lab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.ModelBuilding
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            // Rename table column and schema name
            /*modelBuilder
                .Entity<Employee>()
                .ToTable("People", "company");*/

            // select the property that we will modify
            builder
                .Property(x => x.StartWorkDate) 
                .HasColumnName("StartedOn");

            // Set primary ket if name is not "Id"
            //modelBuilder.Entity<Employee>()
            //      .HasKey(x => x.Id);

            // Flag Egn as not null, so it can be a part of a composite key
            builder.Property(x => x.Egn).IsRequired();

            // Auto increment Id
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //Create composite key
            //builder.HasKey(x => new {x.Id, x.Egn});

            // Allow nulls
            builder.Property(x => x.FirstName).IsRequired(); // NOT NULL
            builder.Property(x => x.LastName).IsRequired(); // NOT NULL

            // Limit text length
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.LastName).HasMaxLength(30);

            // Flag a property to not be created in DB
            builder.Ignore(x => x.FullName);

            // One to many relationship with fluent API
            builder
                .HasOne(x => x.Department) // required
                .WithMany(x => x.Employees) // optional (inverse)
                .HasForeignKey(x => x.DepartmentId) // db column name (optional)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete options
        }
    }
}
