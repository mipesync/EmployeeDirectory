using EmployeeDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeDirectory.Persistence.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id)
                .IsUnique();

            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.MiddleName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.FullName)
                .HasMaxLength(95)
                .IsRequired();
        }
    }
}
