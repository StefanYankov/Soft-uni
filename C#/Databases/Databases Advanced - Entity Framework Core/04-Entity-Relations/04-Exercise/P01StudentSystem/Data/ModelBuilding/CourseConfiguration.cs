using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;


namespace P01_StudentSystem.Data.ModelBuilding
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsUnicode(true);
            builder.Property(c => c.Description).IsUnicode(true).IsRequired(false);
        }
    }
}
