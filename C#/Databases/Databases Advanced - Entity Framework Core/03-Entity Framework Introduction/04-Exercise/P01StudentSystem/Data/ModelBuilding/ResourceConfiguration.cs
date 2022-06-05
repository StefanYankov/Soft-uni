using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;


namespace P01_StudentSystem.Data.ModelBuilding
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.Property(r => r.Name).IsUnicode(true);
            builder.Property(r => r.Url).IsUnicode(false);
            builder.Property(r => r.ResourceType).HasConversion( et => et.ToString(), et => (ResourceType)Enum.Parse(typeof(ResourceType), et));
        }
    }
}
