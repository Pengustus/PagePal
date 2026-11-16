using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagePal.Data.Entities;

namespace PagePal.Data.Configurations;

public class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.InventoryNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(c => c.InventoryNumber)
            .IsUnique();

        builder.Property(c => c.Condition)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(c => c.RowVersion)
            .IsRowVersion();

        builder.HasOne(c => c.BookTitle)
            .WithMany(b => b.Copies)
            .HasForeignKey(c => c.BookTitleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Loans)
            .WithOne(l => l.BookCopy)
            .HasForeignKey(l => l.BookCopyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
