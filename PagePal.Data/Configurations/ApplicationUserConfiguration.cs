using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagePal.Data.Entities;

namespace PagePal.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.LibraryCardNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(u => u.LibraryCardNumber)
            .IsUnique();
    }
}
