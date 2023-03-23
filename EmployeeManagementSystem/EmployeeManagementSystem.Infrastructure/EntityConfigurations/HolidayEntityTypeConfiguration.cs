using EmployeeManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.EntityConfigurations
{
    internal class HolidayEntityTypeConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.Property(e => e.HolidayDate).HasColumnType("date");

            builder.Property(e => e.HolidayName)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }

}
    

