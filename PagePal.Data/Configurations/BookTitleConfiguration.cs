using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagePal.Data.Entities;

namespace PagePal.Data.Configurations;

public class BookTitleConfiguration : IEntityTypeConfiguration<BookTitle>
{
    public void Configure(EntityTypeBuilder<BookTitle> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(b => b.ISBN);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(b => b.Genre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .HasMaxLength(2000);

        builder.Property(b => b.CoverImageUrl)
            .HasMaxLength(500);

        builder.HasMany(b => b.Copies)
            .WithOne(c => c.BookTitle)
            .HasForeignKey(c => c.BookTitleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.Reservations)
            .WithOne(r => r.BookTitle)
            .HasForeignKey(r => r.BookTitleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
