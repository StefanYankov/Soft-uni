using Lab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.ModelBuilding
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //one to one relationship with fluent api
            /*builder
                .HasOne(a => a.Employee)
                .WithOne(e => e.Address);*/
        }
    }
}
